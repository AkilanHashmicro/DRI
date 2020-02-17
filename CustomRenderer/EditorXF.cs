using System;

using Xamarin.Forms;

namespace SalesApp
{
    public class EditorXF : Editor     {         public EditorXF()         {             this.TextChanged += EditorXF_TextChanged;         }          private void EditorXF_TextChanged(object sender, TextChangedEventArgs e)         {             this.InvalidateMeasure();         }      } 
}

