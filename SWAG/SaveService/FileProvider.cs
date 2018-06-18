namespace SWAG.SaveService
{
    using SWAG.OperationFactory;
    using System;
    using System.IO;
    using System.Text;
    using System.Threading.Tasks;

    public class FileProvider : ISaveProvider
    {
        public readonly string _fileName = "result.txt";
        public IOperationFactory _operationFactory;
        public Encoding Encoding => Encoding.UTF8;

        public FileProvider(IOperationFactory operationFactory)
        {
            _operationFactory = operationFactory;
        }
        public double? GetResult(Guid id)
        {

            string line = String.Empty;
            string filePath = Directory.GetCurrentDirectory() + _fileName;

            if (File.Exists(filePath)) throw new FileNotFoundException("Database is empty! Send request to calculate some expression");

            using (StreamReader sr = new StreamReader(filePath, Encoding))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    var data = line.Split(' ');
                    if (Guid.Parse(data[0]) == id) return Double.Parse(data[1]);
                }
            }
            return null;
        }

        public async Task<Guid> Save(OperationDTO data)
        {
            var operationService = _operationFactory.GetOperation(data.Operation);
            var result = await operationService.Calc(data.Right, data.Left);
            var id = SaveToStorage(result);
            return id;
        }

        private Guid SaveToStorage(double value)
        {
            Guid id = Guid.NewGuid();

            string filePath = $"{Directory.GetCurrentDirectory()}/{_fileName}";
            using (StreamWriter sw = new StreamWriter(filePath, true, Encoding))
            {
                sw.WriteLine($"{id} {value}");
            }
            return id;
        }
    }
}
