namespace NHibernateSample.Data.Entidades
{
    public class Teste
    {
        public virtual int Id { get; set; }
        public virtual string Descricao { get; set;}

        protected Teste()
        {
            
        }

        public Teste(string descricao)
        {
            Descricao = descricao;
        }
    }
}
