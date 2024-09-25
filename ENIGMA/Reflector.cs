namespace ENIGMA
{
    public class Reflector
    {
        private int[] type = new int[26];

        // конструктор по строке
        public Reflector(string type)
        {
            for (int i = 0; i < type.Length; i++)
                this.type[i] = type[i] - 'A';
        }

        // "отражение" сигнала
        public int PassThrough(int Input) => type[Input];
    }
}
