using System;
using System.Collections.Generic;

namespace ENIGMA
{
    public class Enigma
    {

        // все виды роторов
        private static Dictionary<string, string> RotTypes = new Dictionary<string, string>(){
            {"RotorI", "EKMFLGDQVZNTOWYHXUSPAIBRCJR"},
            {"RotorII", "AJDKSIRUXBLHWTMCQGZNPYFVOEF"},
            {"RotorIII", "BDFHJLCPRTXVZNYEIWGAKMUSQOW"},
            {"RotorIV", "ESOVPZJAYQUIRHXLNFTGKDCMWBK"},
            {"RotorV", "VZBRGITYUPSDNHLXAWMJQOFECKA"},
            {"RotorVI", "JPGVOUMFYQBENHZRDKASXLICTWA"},
            {"RotorVII", "NZJHGRCXMYSWBOUFAIVLPEKQDTA"},
            {"RotorVIII", "FKQHTLXOCBJSPDZRAMEWNIUYGVA"},
            {"BetaRotor", "LEYJVCNIXWPBQMDRTAKZGFUHOSA"},
            {"GammaRotor", "FSOKANUERHMBTIYCWLQPZXVGJDA"}
        };

        // все виды рефлекторов
        private static Dictionary<string, string> RefTypes = new Dictionary<string, string>(){
            {"ReflectorB", "YRUHQSLDPXNGOKMIEBFZCWVJAT"},
            {"ReflectorC", "FVPJIAOYEDRZXWGCTKUQSBNMHL"},
            {"ReflectorBDunn", "ENKQAUYWJICOPBLMDXZVFTHRGS"},
            {"ReflectorCDunn", "RDOBJNTKVEHMLFCWZAXGYIPSUQ"},
        };

        // создаем роторы, рефлектор и панель коммутации
        public RotorStack Rots = new(RotTypes["RotorI"], RotTypes["RotorII"], RotTypes["RotorIII"]);
        public PlugBoard PB = new();
        Reflector Ref = new(RefTypes["ReflectorB"]);

        public Enigma() { }

        // поворот одного из роторов
        public void Rotate(int offset, int num) => Rots.Rotate(offset, num);
        // поворот кольа одного из роторов 
        public void SetRing(int offset, int num) => Rots.SetRing(offset, num);
        // смена ротора
        public void ChangeRotor(string type, int num) => Rots.ChangeRotor(RotTypes[type], num);
        // смена рефлектора
        public void ChangeReflector(string type) => Ref = new Reflector(RefTypes[type]);
        // шифрование: входи -> панель коммутации -> роторы -> рефлектор -> роторы -> панель коммутации -> выход
        public char Encrypt(char input)
        {
            int res = PB.PassThrough(input) - 'A';
            res = Rots.Encrypt(res, true);
            res = Ref.PassThrough(res);
            res = Rots.Encrypt(res, false);
            return PB.PassThrough(Convert.ToChar(res + 'A'));
        }
    }
}
