﻿using System;


namespace Modelo
{
    public class ModeloSubCategoria
    {
        public ModeloSubCategoria()
        {
            this.CatCod = 0;
            this.SCatCod = 0;
            this.SCatNome = "";
        }

        public ModeloSubCategoria(int sCatCod, int catCod, string sCatNome)
        {            
            this.CatCod = catCod;
            this.SCatCod = sCatCod;
            this.SCatNome = sCatNome;
        }

        private int cat_cod;
        public int CatCod
        {
            get { return this.cat_cod; }
            set { this.cat_cod = value; }
        }

        private int scat_cod;
        public int SCatCod
        {
            get { return this.scat_cod; }
            set { this.scat_cod = value; }
        }

       
        private String scat_nome;
        public String SCatNome
        {
            get { return this.scat_nome; }
            set { this.scat_nome = value; }
        }


    }
}