using System;
using Livet.Messaging;
using System.Runtime.Serialization;

namespace Livet
{
    /// <summary>
    /// ViewModelの基底クラスです。
    /// </summary>
    [DataContract]
    public abstract class ViewModel : NotificationObject,IDisposable
    {
        [IgnoreDataMember]
        private bool _disposed;
        [IgnoreDataMember]
        private InteractionMessenger _messenger;
        [IgnoreDataMember]
        private LivetCompositeDisposable _compositeDisposable;

        /// <summary>
        /// このViewModelクラスの基本CompositeDisposableです。
        /// </summary>
        [DataMember]
        public LivetCompositeDisposable CompositeDisposable
        {
            get
            {
                if (_compositeDisposable == null)
                {
                    _compositeDisposable = new LivetCompositeDisposable();
                }
                return _compositeDisposable;
            }
            set
            {
                _compositeDisposable = value;
            }
        }

        /// <summary>
        /// このViewModelクラスの基本Messegerインスタンスです。
        /// </summary>
        [DataMember]
        public InteractionMessenger Messenger
        {
            get
            {
                if (_messenger == null)
                {
                    _messenger = new InteractionMessenger();
                }
                return _messenger;
            }
            set
            {
                _messenger = value;
            }
        }

        /// <summary>
        /// このインスタンスによって使用されているすべてのリソースを解放します。
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;
            if (disposing)
            {
                if (_compositeDisposable != null)
                {
                    _compositeDisposable.Dispose();
                }
            }
            _disposed = true;
        }
    }
}