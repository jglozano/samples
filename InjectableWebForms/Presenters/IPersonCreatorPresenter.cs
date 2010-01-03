namespace InjectableWebForms.Presenters {
    using Views;

    public interface IPersonCreatorPresenter {
        void Associate(IPersonCreateView view);
        void Create();
    }
}