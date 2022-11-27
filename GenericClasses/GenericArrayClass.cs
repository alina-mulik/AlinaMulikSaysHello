namespace GenericsClasses
{
    public class GenericArrayClass<T> where T : Human, new()
    {
        private T[] _objectsArray;
        internal T[] ObjectsArray { get { return _objectsArray; } set { _objectsArray = value; } }
        public GenericArrayClass()
        {
            ObjectsArray = new T[] {  };
        }
        public GenericArrayClass(T objectName)
        {
            ObjectsArray = new T[] { objectName };
        }

        public void AddObjectToArray(T nameOfObjectToAddInArray)
        {
            var arrayLength = _objectsArray.Length + 1;
            Array.Resize(ref _objectsArray, arrayLength);
            _objectsArray.SetValue(nameOfObjectToAddInArray, _objectsArray.Length - 1);
        }

        public void RemoveObjectsFromArray(T elementToDelete)
        {
            for (int a = Array.IndexOf(_objectsArray, elementToDelete); a < _objectsArray.Length - 1; a++)
            {
                _objectsArray[a] = _objectsArray[a + 1];
            }
            Array.Resize(ref _objectsArray, _objectsArray.Length - 1);
            Console.WriteLine($"The element {elementToDelete.HumanFistName} {elementToDelete.HumanLastName} has been deleted from the array.");
        }

        public void OutputFirstNamesOfItemsInArray()
        {
            var arrayOfNames = _objectsArray.Select(item => item.HumanFistName).ToArray();
            Console.WriteLine("All First Names of elements in array:");
            Array.ForEach(arrayOfNames, item => Console.WriteLine(item));
        }

        public T GetObjectFromArrayByIndex(int index) => _objectsArray[index];

        public int GetArrayLength()
        {
            return _objectsArray.Length;
        }
    }
}
