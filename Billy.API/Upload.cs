using System;
using System.Collections.Generic;
using System.Text;
using Billy.Models.Params;
using Billy.Helpers;
using System.Net;
using System.IO;
using System.Security.Cryptography;

namespace Billy.API
{
    public static class Upload
    {
        class MultiPartForm : IDisposable
        {
            private Stream _stream;
            private string _boundary;
            private string _templateData = "--{0}\r\nContent-Disposition: form-data; name=\"{1}\"\r\n\r\n{2}\r\n";
            private string _templateFile = "--{0}\r\nContent-Disposition: form-data; name=\"{1}\"; filename=\"{2}\"\r\nContent-Type: {3}\r\n\r\n";
            private string _templateEnd = "--{0}--\r\n\r\n";

            public MultiPartForm(WebRequest Request)
            {
                _boundary = String.Format("--{0}", GetMD5());
                Request.Method = "POST";
                Request.ContentType = String.Format("multipart/form-data; boundary={0}", _boundary);
                _stream = Request.GetRequestStream();
            }

            public void AddData(string Name, string Value)
            {
                byte[] contentData = Encoding.UTF8.GetBytes(String.Format(_templateData, _boundary, Name, Value));
                _stream.Write(contentData, 0, contentData.Length);
            }

            public void AddFile(string Name, string FilePath)
            {
                AddFile(Name, FilePath, "application/octet-stream");
            }

            public void AddFile(string Name, string FilePath, string FileType)
            {
                using (FileStream fileStream = new FileStream(FilePath, FileMode.Open))
                {
                    AddFile(Name, FilePath, fileStream, FileType);
                }
            }

            public void AddFile(string Name, string FilePath, Stream FileStream)
            {
                AddFile(Name, FilePath, FileStream, "application/octet-stream");
            }

            public void AddFile(string Name, string FilePath, Stream FileStream, string FileType)
            {
                FileStream.Seek(0, SeekOrigin.Begin);
                byte[] contentFile = Encoding.UTF8.GetBytes(String.Format(_templateFile, _boundary, Name, FilePath, FileType));
                _stream.Write(contentFile, 0, contentFile.Length);
                FileStream.CopyTo(_stream);
                byte[] _lineFeed = Encoding.UTF8.GetBytes("\r\n");
                _stream.Write(_lineFeed, 0, _lineFeed.Length);
            }

            public void Dispose()
            {
                Close();
                GC.SuppressFinalize(this);
            }

            public void Close()
            {
                byte[] contentEnd = Encoding.UTF8.GetBytes(String.Format(_templateEnd, _boundary));
                _stream.Write(contentEnd, 0, contentEnd.Length);
            }

            private string GetMD5()
            {
                Random randNum = new Random();
                MD5CryptoServiceProvider md5hash = new MD5CryptoServiceProvider();
                byte[] randByte = Encoding.UTF8.GetBytes(randNum.NextDouble().ToString());
                byte[] computeHash = md5hash.ComputeHash(randByte);
                string resultHash = String.Empty;
                foreach (byte currentByte in computeHash)
                {
                    resultHash += currentByte.ToString("x2");
                }
                return resultHash;
            }
        }

        public static string Photo(string photo, string url)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            using (MultiPartForm multiPart = new MultiPartForm(webRequest))
            {
                multiPart.AddData("method", "post");
                multiPart.AddFile("photo", photo);
            }
            HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();

            var stream = webResponse.GetResponseStream();
            string text;
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                text = reader.ReadToEnd();
            }
            return text;
        }
    }
}
