public class Map{
    private Item[,] mapa; //o atributo mapa será uma matriz de itens
    public int dimensão {get; private set;}
    
    public Map(int nivel, int dimensão = 10){
        this.dimensão = dimensão <= 30 ? dimensão:30;
        mapa = new Item[dimensão, dimensão];

        for(int i = 0; i< mapa.GetLength(0); i++){
            for(int j = 0; j< mapa.GetLength(1); j++){
                mapa[i,j] = new Terreno();
            }
        }
        if(nivel == 1){
            Criar_Mapa1();
        }else{
            CriarMapaAleatório();
        }
    }

    public void Imprime(){
        for(int i = 0; i< mapa.GetLength(0); i++){
            for(int j = 0; j< mapa.GetLength(1); j++){
                Console.Write(mapa[i,j]);
            }
            Console.Write("\n");
        }
    }

    public void Alocar(Item objeto, int x, int y){
        mapa[x,y] = objeto;
    }

    public void Criar_Mapa1(){
        this.Alocar(new Red(), 1, 9);
        this.Alocar(new Red(), 8, 8);
        this.Alocar(new Green(), 9, 1);
        this.Alocar(new Green(), 7, 6);
        this.Alocar(new Blue(), 3, 4);
        this.Alocar(new Blue(), 2, 1);
        this.Alocar(new Water(), 5, 0);
        this.Alocar(new Water(), 5, 1);
        this.Alocar(new Water(), 5, 2);
        this.Alocar(new Water(), 5, 3);
        this.Alocar(new Water(), 5, 4);
        this.Alocar(new Water(), 5, 5);
        this.Alocar(new Water(), 5, 6);
        this.Alocar(new Tree(), 5, 9);
        this.Alocar(new Tree(), 3, 9);
        this.Alocar(new Tree(), 8, 3);
        this.Alocar(new Tree(), 2, 5);
        this.Alocar(new Tree(), 1, 4);
    }

    private void CriarMapaAleatório(){
        Random k = new Random(1);

        for(int x = 0; x< 3; x++){
            int  xRandom = k.Next(0, dimensão);
            int  yRandom = k.Next(0, dimensão);
            this.Alocar(new Blue(), xRandom, yRandom);
        }
        for(int x = 0; x< 3; x++){
            int  xRandom = k.Next(0, dimensão);
            int  yRandom = k.Next(0, dimensão);
            this.Alocar(new Green(), xRandom, yRandom);
        }
        for(int x = 0; x< 3; x++){
            int  xRandom = k.Next(0, dimensão);
            int  yRandom = k.Next(0, dimensão);
            this.Alocar(new Red(), xRandom, yRandom);
        }
        for(int x = 0; x< 3; x++){
            int  xRandom = k.Next(0, dimensão);
            int  yRandom = k.Next(0, dimensão);
            this.Alocar(new Tree(), xRandom, yRandom);
        }
        for(int x = 0; x< 3; x++){
            int  xRandom = k.Next(0, dimensão);
            int  yRandom = k.Next(0, dimensão);
            this.Alocar(new Water(), xRandom, yRandom);
        }
        for(int x = 0; x< 3; x++){
            int  xRandom = k.Next(0, dimensão);
            int  yRandom = k.Next(0, dimensão);
            this.Alocar(new Toxin(), xRandom, yRandom);
        }

    }

    public void Mudança(int Xi,int Yi, int Xf,int Yf ){
        mapa[Xf, Yf] = mapa[Xi,Yi];
        mapa[Xi,Yi] = new Terreno();
    }
    public int Remover_Joias(int x, int y){
        int a1 = x-1, a2 = y-1, b1 = x+2, b2 = y+2 ;
        if(x == 0){
            a1 = 0;
        }
        if(x == dimensão-1){
            b1 = x+1;
        }
        if(y == 0){
            a2 = 0;
        }
        if(y == dimensão-1){
            b2 = y+1;
        }
        for(int i = a1; i < b1; i++){
            for(int j = a2 ; j < b2; j++){
                if(mapa[i, j] is Item){
                    if(mapa[i,j] is Red){
                        mapa[i, j] = new Terreno();
                        return 100;
                    }
                    if(mapa[i,j] is Green){
                        mapa[i, j] = new Terreno();
                        return 50;
                    }
                    if(mapa[i,j] is Blue){
                        mapa[i, j] = new Terreno(); 
                        return 10;
                    }
                    if(mapa[i,j] is Tree){
                        mapa[i, j] = new Terreno(); 
                        return 1;
                    }
                }
            }
        }
        return 0;
        
    }
    public bool  Possivel_Movimento(string direção, int x, int y){
        if(direção == "mov_norte"){
            if(x-1 != -1 && mapa[x-1,y] is not Jewel && mapa[x-1,y] is not Obstacle){
                return true;
            }else {
                return false;
            }
        }
        if(direção == "mov_sul"){
            if(x+1 != dimensão && mapa[x+1,y] is not Jewel && mapa[x+1,y] is not Obstacle){
                return true;
            }else{
                return false;
            }
        }
        if(direção == "mov_leste"){
            if(y+1 != dimensão && mapa[x,y+1] is not Jewel  && mapa[x,y+1] is not Obstacle){
                return true;
            }else {
                return false;
            }
        }
        if(direção == "mov_oeste"){
            if(y-1 != -1 && mapa[x,y-1] is not Jewel && mapa[x,y-1] is not Obstacle){
                return true;
            }else {
                return false;
            }
        }
    return true;
    }

    public bool Tem_Joia(){
        for(int i = 0; i< mapa.GetLength(0); i++){
            for(int j = 0; j< mapa.GetLength(1); j++){
                if(mapa[i,j] is Jewel){
                    return true;
                }
            }
        }
        return false;
    }


    public int Joias_Proximas(int x, int y){
        int a1 = x-1, a2 = y-1, b1 = x+2, b2 = y+2 ;
        if(x == 0){
            a1 = 0;
        }
        if(x == dimensão-1){
            b1 = x+1;
        }
        if(y == 0){
            a2 = 0;
        }
        if(y == dimensão-1){
            b2 = y+1;
        }
        int contador = 0; 
        for(int i = a1; i < b1; i++){
            for(int j = a2 ; j < b2; j++){
                if(mapa[i, j] is Jewel){
                    contador++;
                }
            }
        }
        return contador;
        
    }

    public int Arvores_Proximas(int x, int y){
        int a1 = x-1, a2 = y-1, b1 = x+2, b2 = y+2 ;
        if(x == 0){
            a1 = 0;
        }
        if(x == dimensão-1){
            b1 = x+1;
        }
        if(y == 0){
            a2 = 0;
        }
        if(y == dimensão-1){
            b2 = y+1;
        }
        int contador = 0; 
        for(int i = a1; i < b1; i++){
            for(int j = a2 ; j < b2; j++){
                if(mapa[i, j] is Tree){
                    contador++;
                }
            }
        }
        return contador;
        
    }
    public int Toxinas_Proximas(int x, int y){
        int a1 = x-1, a2 = y-1, b1 = x+2, b2 = y+2 ;
        if(x == 0){
            a1 = 0;
        }
        if(x == dimensão-1){
            b1 = x+1;
        }
        if(y == 0){
            a2 = 0;
        }
        if(y == dimensão-1){
            b2 = y+1;
        }
        int contador = 0; 
        for(int i = a1; i < b1; i++){
            for(int j = a2 ; j < b2; j++){
                if(mapa[i, j] is Toxin){
                    contador++;
                }
            }
        }
        return contador;
        
    }

} 