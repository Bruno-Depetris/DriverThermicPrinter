using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

class ObservableExample {
    ObservableCollection<string> printers = new ObservableCollection<string>();

    public ObservableExample() {
        printers.CollectionChanged += OnPrintersChanged;
        printers.Add("Impresora Térmica 1");
    }

    private void OnPrintersChanged(object sender, NotifyCollectionChangedEventArgs e) {
        Console.WriteLine("Collection changed: " + e.Action);
    }
}   