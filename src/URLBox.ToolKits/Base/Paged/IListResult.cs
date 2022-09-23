namespace URLBox.ToolKits.Base.Paged
{
    public interface IListResult<T>
    {
        /// <summary>
        /// 返回结果
        /// </summary>
        IReadOnlyList<T> Item { get; set; }
    }
}
