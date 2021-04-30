using System;
using System.Collections;
using Android.Support.V7.Widget;
using Android.Views;

namespace Proyectos1
{
    public class Adaptador: RecyclerView.Adapter
    {
        ArrayList lista;
        
        public Adaptador(ArrayList lista)
        {
            this.lista = lista;
        }

        public override int ItemCount => lista.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            throw new NotImplementedException();
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            throw new NotImplementedException();
        }
    }

    public class Holder : RecyclerView.ViewHolder
    {
        

        public Holder(View v) : base(v)
        {


        }

    }
}
