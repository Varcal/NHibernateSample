namespace NHibernateSample.Data.Entidades
{
    public class Teste
    {
        public virtual int Id { get; private set; }
        public virtual string Descricao { get; private set; }

        protected Teste()
        {
            
        }

        public Teste(string descricao)
        {
            Descricao = descricao;
        }
    }
}
