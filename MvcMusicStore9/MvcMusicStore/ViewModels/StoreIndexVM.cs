namespace MvcMusicStore.ViewModels
{
    public class StoreIndexVM
    {
        public int NumberOfGenres { get; set; } // Niet vergeten dat je prop + tab + tab kan doen om property snel toe te voegen
        public List<string>? Genres { get; set; } // ? wilt zeggen dat het kan leeg zijn
        // ^ This definition is using the List<T> type, where T constrains the type to which elements of this List belong to, in this case Genres (or any of its descendants).
        // ^ This ability to design classes and methods that defer the specification of one or more types until the class or method isdeclared and instantiated by client code is a feature of the C# language called Generics.
        // ^ List<T> is the generic equivalent of the ArrayList type and is available in the System.Collections.Generic namespace. One of the benefits of using generics is that since the type is specified, you do not need to take care of type checking operations such as casting the elements into Genres as you would do with an ArrayList.

    }
}
