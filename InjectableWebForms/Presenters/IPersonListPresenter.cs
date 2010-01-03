namespace InjectableWebForms.Presenters {
    using Views;

    public interface IPersonListPresenter {
        void Associate(IPersonListView view);
        void LoadList();
    }
}