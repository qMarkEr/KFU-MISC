using System;

namespace ENIGMA
{
    public class Rotor
    {
        private int[] type = new int[26];
        private int position = 0; // позиция кольца ротора
        public int notch { get; } // выемка
        public int Rotation { get; set; } // позиция ротора
        
        // конструктор по строке
        public Rotor(string type)
        {
            for (int i = 0; i < 26; i++)
                this.type[i] = type[i] - 'A';
            notch = type[26] - 'A';
        }

        // поворот кольца (смещение алфавита)
        public void SetRing(int offset)
        {
            int[] temp = new int[26];
            Array.Copy(type, temp, 26);
            for (int i = 0; i < type.Length; i++)
                type[i] = temp[Cycle(i - offset)];
            position += offset;
        }
        // шифрование. Работает в обе стороны
        public int PassThrough(int input, bool direction) =>
            direction ? Cycle(type[Cycle(input + Rotation)] - Rotation + position) :
                Cycle(Array.IndexOf(type, Cycle(input + Rotation - position)) - Rotation);

        private int Cycle(int ch) => (ch + 26) % 26;

    }
}
