public abstract class Item { //será a classe mãe do Robô, das joias e dos obstáculos.
    
    private string Caracteres; //atributo do tipo string que será o símbolo de cada item.

    public Item(string Caracteres){  //aqui, temos o construtor da classe Item.
        this.Caracteres = Caracteres;
    }
    public sealed override string ToString(){ 
        return Caracteres;
    }

}