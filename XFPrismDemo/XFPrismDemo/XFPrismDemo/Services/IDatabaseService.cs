using XFPrismDemo.LocalDBs;

namespace XFPrismDemo.Services
{
    public interface IDatabaseService
    {
        TodoItemDatabase TodoItemDatabase { get; }
    }
}
