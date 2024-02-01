using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text;

namespace TwojaNazwaProjektu.Controllers
{
    public class PolybiusController : Controller
    {
       
        private Dictionary<char, string> PolybiusAlphabet = new Dictionary<char, string>
        {
            {'a', "11"}, {'ą', "12"}, {'b', "13"}, {'c', "14"}, {'ć', "15"},
            {'d', "21"}, {'e', "22"}, {'ę', "23"}, {'f', "24"}, {'g', "25"},
            {'h', "31"}, {'i', "32"}, {'j', "33"}, {'k', "34"}, {'l', "35"},
            {'ł', "41"}, {'m', "42"}, {'n', "43"}, {'ń', "44"}, {'o', "45"},
            {'ó', "51"}, {'p', "52"}, {'q', "53"}, {'r', "54"}, {'s', "55"},
            {'ś', "61"}, {'t', "62"}, {'u', "63"}, {'v', "64"}, {'w', "65"},
            {'x', "71"}, {'y', "72"}, {'z', "73"}, {'ź', "74"}, {'ż', "75"},
            {' ', "88"}
        };

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Encrypt(string inputText)
        {
            
            StringBuilder encryptedText = new StringBuilder();
            foreach (char letter in inputText.ToLower())
            {
                if (PolybiusAlphabet.ContainsKey(letter))
                {
                    encryptedText.Append(PolybiusAlphabet[letter]);
                }
                else
                {
                    
                    encryptedText.Append(letter);
                }
            }

            ViewBag.EncryptedText = encryptedText.ToString();
            return View("Index");
        }

        [HttpPost]
        public IActionResult Decrypt(string inputText)
        {
            
            StringBuilder decryptedText = new StringBuilder();
            for (int i = 0; i < inputText.Length; i += 2)
            {
                string code = inputText.Substring(i, 2);
                foreach (var kvp in PolybiusAlphabet)
                {
                    if (kvp.Value == code)
                    {
                        decryptedText.Append(kvp.Key);
                        break;
                    }
                }
            }

            ViewBag.DecryptedText = decryptedText.ToString();
            return View("Index");
        }
    }
}
