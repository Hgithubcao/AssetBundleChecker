using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;

namespace AssetBundleChecker
{
    public partial class AssetBundleChecker : Form
    {
        public AssetBundleChecker()
        {
            InitializeComponent();
        }

        private static void CompressFileLZMA(string inFile, string outFile)
        {
            SevenZip.Compression.LZMA.Encoder coder = new SevenZip.Compression.LZMA.Encoder();
            FileStream input = new FileStream(inFile, FileMode.Open);
            FileStream output = new FileStream(outFile, FileMode.Create);

            // Write the encoder properties
            coder.WriteCoderProperties(output);

            // Write the decompressed file size.
            output.Write(System.BitConverter.GetBytes(input.Length), 0, 8);

            // Encode the file.
            coder.Code(input, output, input.Length, -1, null);
            output.Flush();
            output.Close();
            input.Close();
            System.GC.Collect();
        }

        public static void DecompressFileLZMA(string inFile, string outFile)
        {
            SevenZip.Compression.LZMA.Decoder coder = new SevenZip.Compression.LZMA.Decoder();
            FileStream input = new FileStream(inFile, FileMode.Open);
            FileStream output = new FileStream(outFile, FileMode.Create);

            // Read the decoder properties
            byte[] properties = new byte[5];
            input.Read(properties, 0, 5);

            // Read in the decompress file size.
            byte[] fileLengthBytes = new byte[8];
            input.Read(fileLengthBytes, 0, 8);
            long fileLength = BitConverter.ToInt64(fileLengthBytes, 0);

            // Decompress the file.
            coder.SetDecoderProperties(properties);
            coder.Code(input, output, input.Length, fileLength, null);
            output.Flush();
            output.Close();
            input.Close();
        }

        public static string HttpGetString(string uri)
        {
            WebRequest req = WebRequest.Create(uri);
            WebResponse res = req.GetResponse();    // GetResponse blocks until the response arrives
            Stream ReceiveStream = res.GetResponseStream();    // Read the stream into a string
            StreamReader sr = new StreamReader(ReceiveStream);
            string resultstring = sr.ReadToEnd();
            return resultstring;
        }

        public static void HttpDownload(string uri, string savePath)
        {
            WebRequest req = WebRequest.Create(uri);
            WebResponse res = req.GetResponse();    // GetResponse blocks until the response arrives
            Stream ReceiveStream = res.GetResponseStream();    // Read the stream into a string
            FileStream fs = new FileStream(savePath, FileMode.Create);
            byte[] buffer = new byte[4096];
            int readedLength = ReceiveStream.Read(buffer, 0, buffer.Length);
            while (readedLength > 0)
            {
                fs.Write(buffer, 0, readedLength);
                readedLength = ReceiveStream.Read(buffer, 0, buffer.Length);
            }
            fs.Flush();
            fs.Close();
            ReceiveStream.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cdnUrl = CdnUrl.Text;
            string bundleIdxStr = HttpGetString(BundleIdxUrl.Text);
            string[] bundleInfoArr = bundleIdxStr.Split('\n');
            foreach (string bundleInfoStr in bundleInfoArr)
            {
                if (bundleInfoStr.IndexOf('/') < 0)
                    continue;
                string[] bundleInfoParams = bundleInfoStr.Split('|');
                string bundlePath = bundleInfoParams[0] + "_" + bundleInfoParams[5] + ".zip";
                try
                {
                    HttpDownload(cdnUrl + '/' + bundlePath, "LZMA/" + bundlePath);
                }
                catch
                {
                    Result.AppendText("Download failed: " + bundlePath);
                }
                try
                {
                    DecompressFileLZMA("LZMA/" + bundlePath, "Uncompressed/" + bundleInfoParams[0] + "_" + bundleInfoParams[5] + ".unity3d");
                }
                catch
                {
                    Result.AppendText("Decompress failed: " + bundlePath);
                }
            }
        }

        private void Url_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
