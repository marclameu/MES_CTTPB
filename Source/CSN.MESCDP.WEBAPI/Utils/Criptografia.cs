using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CTTPB.MESCDP.Application.WebApi.Utils
{
    public class Criptografia
    {
        // Caracteres gerados pelo site Random.Org
        private static string _key = "hpol6QwMxy2SYNeDQufbRWtY";
        private static string IV = "pPciqcrf";

        public static string Key
        {
            get { return _key; }
            set { _key = value; }
        }

        /// <summary>
        ///  Decriptografa a string passada como parametros
        /// </summary>
        /// <param name="input"></param>
        /// <returns>string Decriptografada</returns>
        public static string Decriptografar(string input)
        {
            TripleDESCryptoServiceProvider TDES = new TripleDESCryptoServiceProvider();

            byte[] valor = Convert.FromBase64CharArray(input.ToCharArray(), 0, input.Length);

            byte[] fromEncrypt = new byte[valor.Length];

            ICryptoTransform encrypt = TDES.CreateDecryptor(ASCIIEncoding.ASCII.GetBytes(_key), ASCIIEncoding.ASCII.GetBytes(IV));

            MemoryStream memStreamnDecryptedData = new MemoryStream(valor);

            CryptoStream encStream = new CryptoStream(memStreamnDecryptedData,
                                            encrypt,
                                            CryptoStreamMode.Read);

            try
            {
                //Encrypt the data, write it to the memory stream. 
                encStream.Read(fromEncrypt, 0, fromEncrypt.Length);
            }
            catch
            {
                throw new Exception("Erro ao decriptografar.");
            }

            string retorno = ASCIIEncoding.ASCII.GetString(fromEncrypt);
            memStreamnDecryptedData.Close();
            //Tirar caracter de final de string
            return retorno.Replace('\0', ' ').Trim();
        }

        /// <summary>
        /// Criptografa a string passada como parâmetro
        /// </summary>
        /// <param name="valor"></param>
        /// <returns>string criptografada</returns>
        public static string Criptografar(string valor)
        {
            //Cria o servico de criptografia
            TripleDESCryptoServiceProvider TDES = new TripleDESCryptoServiceProvider();

            byte[] bytesData = ASCIIEncoding.ASCII.GetBytes(valor);

            ICryptoTransform encrypt = TDES.CreateEncryptor(ASCIIEncoding.ASCII.GetBytes(_key), ASCIIEncoding.ASCII.GetBytes(IV));

            MemoryStream memStreamEncryptedData = new MemoryStream();

            CryptoStream encStream = new CryptoStream(memStreamEncryptedData,
                                            encrypt,
                                            CryptoStreamMode.Write);

            try
            {

                //Encrypt the data, write it to the memory stream. 
                encStream.Write(bytesData, 0, bytesData.Length);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao criptografar.");
            }

            encStream.FlushFinalBlock();

            string retorno = Convert.ToBase64String(memStreamEncryptedData.ToArray());
            encStream.Close();
            memStreamEncryptedData.Close();
            return retorno;

        }
        public static string GetConnectiongStringDecryptedPassword(string rawString)
        {
            string descriptPass;
            int start, end;
            start = rawString.IndexOf("Password=") + 9;
            end = rawString.IndexOf(";", start);
            end = (end == -1) ? rawString.Length : end;

            descriptPass = Decriptografar(rawString.Substring(start, end - start));

            return rawString.Substring(0, start) + descriptPass + rawString.Substring(end);
        }
    }
}

