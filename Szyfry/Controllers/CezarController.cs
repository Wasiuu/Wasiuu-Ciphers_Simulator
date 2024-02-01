using Microsoft.AspNetCore.Mvc;
using System;
using System.Text;


namespace CipherSimulators.Controllers
{
    public class CezarController : Controller
    {
        private readonly char[] alphabet = "aąbcćdeęfghijklłmnńoóprsśtuwyzźż".ToCharArray();
        private const int alphabetLength = 32;

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Encrypt(string inputText, int shift)
        {
            string encryptedText = CaesarCipher(inputText, shift);
            ViewBag.EncryptedText = encryptedText;
            return View("Index");
        }

        [HttpPost]
        public ActionResult Decrypt(string inputText, int shift)
        {
            string decryptedText = CaesarCipher(inputText, -shift);
            ViewBag.DecryptedText = decryptedText;
            return View("Index");
        }

        private string CaesarCipher(string text, int shift)
        {
            StringBuilder result = new StringBuilder();

            foreach (char c in text)
            {
                if (char.IsLetter(c))
                {
                    char baseChar = char.IsUpper(c) ? 'A' : 'a';
                    int index = (Array.IndexOf(alphabet, char.ToLower(c)) + shift + alphabetLength) % alphabetLength;
                    result.Append(char.IsUpper(c) ? char.ToUpper(alphabet[index]) : alphabet[index]);
                }
                else
                {
                    result.Append(c);
                }
            }

            return result.ToString();
        }
    }
}