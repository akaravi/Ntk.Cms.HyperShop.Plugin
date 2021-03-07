namespace Developer.WebApi.FilterEngine
{
    public class ExportFileModel
    {
        public EnumExportFileType FileType { get; set; } = EnumExportFileType.None;
        public EnumExportReceiveMethod RecieveMethod { get; set; } = EnumExportReceiveMethod.Now;
        public int RowCount { get; set; } = 10;
    }
}
