public class Robot : Item{
    public Map visão_do_robô {get; private set;} //é como se o mapa estivesse na cabeça do robô, ele que vai imprimir o mapa.
    private int abscissa, ordenada;
    private int pontos = 0;
    private int Vermelhas = 0;
    private int Verdes = 0;
    private int Azuis = 0;
    public int energia = 10;
    public Robot(Map visão_do_robô, int abscissa = 0, int ordenada = 0) : base("ME "){
        this.visão_do_robô = visão_do_robô;
        this.abscissa = abscissa;
        this.ordenada = ordenada;
        this.visão_do_robô.Alocar(this, abscissa, ordenada);
    }

    public bool Tem_Energia(){
        return this.energia > 0;
    }
    public bool Acabaram_As_Joias(){
        return !visão_do_robô.Tem_Joia();
    }
    // public void Recarrega_Energia(){
    //     if(visão_do_robô.Arvores_Proximas(abscissa,ordenada) != 0){
    //         energia++;
    //     }
    // }
    public void Mover_Sul(){
        if(visão_do_robô.Possivel_Movimento("mov_sul", abscissa, ordenada) == true)
        {
            visão_do_robô.Mudança(this.abscissa, this.ordenada, this.abscissa+1, this.ordenada);
            this.abscissa++;
            this.energia--;
        }
        
    }
     public void Mover_Norte(){
        if(visão_do_robô.Possivel_Movimento("mov_norte", abscissa, ordenada) == true)
        {
            visão_do_robô.Mudança(this.abscissa, this.ordenada, this.abscissa-1, this.ordenada);
            this.abscissa--;
            this.energia--;
        }
    }
     public void Mover_Oeste(){
        if(visão_do_robô.Possivel_Movimento("mov_oeste", abscissa, ordenada) == true){
            visão_do_robô.Mudança(this.abscissa, this.ordenada, this.abscissa, this.ordenada-1);
            this.ordenada--;
            this.energia--;
        }
    }
     public void Mover_Leste(){
        if(visão_do_robô.Possivel_Movimento("mov_leste", abscissa, ordenada) == true){
            visão_do_robô.Mudança(this.abscissa, this.ordenada, this.abscissa, this.ordenada+1);
            this.ordenada++;
            this.energia--;
        }
    }
    
    public void Imprime_visão_do_robô(){
        visão_do_robô.Imprime();
        Console.WriteLine($"joias proximas: {visão_do_robô.Joias_Proximas(abscissa, ordenada)} ");
        Console.WriteLine($"pontos: {pontos}");
        Console.WriteLine($"energia: {energia}");
        Console.WriteLine($"Joias coletadas: {Vermelhas} Vermelhas, {Verdes} Verdes, {Azuis} Azuis");
    }
    public void Pegar_Joias_ou_Arvores(){
        if(visão_do_robô.Joias_Proximas(abscissa, ordenada) != 0 || visão_do_robô.Arvores_Proximas(abscissa, ordenada) !=0){
            int a = visão_do_robô.Remover_Joias(abscissa,ordenada);
            if(a == 100){
                Vermelhas += 1;
            }
            if(a == 50){
                Verdes += 1;
            }
            if(a == 10){
                Azuis += 1;
                energia += 5;
            }
            if(a == 1){
                energia+= 3;
                a = 0;
            }
            pontos += a;
        }
    }
    
    public void EfeitoToxico(){
        if(visão_do_robô.Toxinas_Proximas(abscissa, ordenada) != 0){
            energia = energia - 10;
        }
    }

}