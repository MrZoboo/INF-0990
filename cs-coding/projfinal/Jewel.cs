public abstract class Jewel : Item{
    public int pontos{get; private set;}
    public Jewel(string Caracteres, int pontos) : base(Caracteres){
        this.pontos = pontos;
    }
}