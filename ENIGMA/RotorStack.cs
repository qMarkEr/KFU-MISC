namespace ENIGMA
{
    public class RotorStack
    {
        // класс блока с тремя роторами
        public Rotor[] Rotors = new Rotor[3];
        
       // конструктор по 3 роторам
        public RotorStack(string rot0, string rot1, string rot2)
        {
            Rotors[0] = new Rotor(rot0);
            Rotors[1] = new Rotor(rot1);
            Rotors[2] = new Rotor(rot2);
        }
        // поворот одного ротора
        public void Rotate(int a, int num) => Rotors[num].Rotation = (Rotors[num].Rotation + a + 26) % 26;

        // поворот кольца одного ротора
        public void SetRing(int a, int num) => Rotors[num].SetRing(a);
        
        // замена ротора        
        public void ChangeRotor(string replacement, int num) => Rotors[num] = new Rotor(replacement);
        
        // шифрование. Работает в обе стороны
        public int Encrypt(int Input, bool direction) => direction == true ? toReflector(Input) : fromReflector(Input);

        // шифрование от входа до рефлектора
        private int toReflector(int Input)
        {
            for (int i = 0; i < 3; i++)
                Input = Rotors[i].PassThrough(Input, true);

            return Input;
        }
        // шифрование от рефлектора до выхода
        private int fromReflector(int Input)
        {
            for (int i = 2; i >= 0; i--)
                Input = Rotors[i].PassThrough(Input, false);

            return Input;
        }
    }
}
