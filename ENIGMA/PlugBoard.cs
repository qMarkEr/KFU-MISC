namespace ENIGMA
{
    public class PlugBoard
    {
        // панель коммутации
        private string Commutation = string.Empty;

        // добавление провода 
        public void AddWire(char a, char b)
        {
            if (!Commutation.Contains(a) && !Commutation.Contains(b))
            {
                Commutation = Commutation.Insert(0, a.ToString());
                Commutation += b;
            }
            System.Console.WriteLine(Commutation);
        }

        // удаление провода
        public void RemoveWire(char a)
        {
            if (Commutation.Contains(a))
            {
                int index = Commutation.IndexOf(a);
                Commutation = Commutation.Remove(index, 1);
                Commutation = Commutation.Remove(Commutation.Length - index - 1, 1);
            }
            System.Console.WriteLine(Commutation);
        }

        // коммутация
        public char PassThrough(char a)
        {
            if (Commutation.Contains(a))
                return Commutation[Commutation.Length - Commutation.IndexOf(a) - 1];
            else
                return a;
        }
    }
}
