using Microsoft.Xaml.Interactivity;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Markup;

namespace Livet.Behaviors
{
    /// Windows 8.1: Behaviors SDK - Part #2
    /// http://www.silverlightshow.net/items/Windows-8.1-Behaviors-SDK-Part-2.aspx

    /// <summary>
    /// Implementing a behavior in Windows 8.1 do not mean extending an abstract class, 
    /// like it was in Silverlight, but it requires you to implement a simple interface. 
    /// This interface called IBehavior - it resides under the Microsoft.Xaml.Interactivity 
    /// namespace - is a lightweight version of the Behavior<T> class that we used in 
    /// Silverlight, but it has a drawback. It directly applies to every DependencyObject 
    /// without any distinction, so we cannot apply limitations on the basis of the target 
    /// type. this makes programming slightly more difficult because you have to double 
    /// check that the associated object can be manipulated by your logic.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Behavior<T> : DependencyObject, IBehavior
        where T : DependencyObject
    {
        public T AssociatedObject { get; private set; }

        protected abstract void OnAttached();

        protected abstract void OnDetached();

        DependencyObject IBehavior.AssociatedObject
        {
            get { return this.AssociatedObject; }
        }

        void IBehavior.Attach(DependencyObject associatedObject)
        {
            if (associatedObject != null &&
                !associatedObject.GetType().GetTypeInfo().IsSubclassOf(typeof(T)))
                throw new Exception("Invalid target type");

            this.AssociatedObject = associatedObject as T;
            this.OnAttached();
        }

        void IBehavior.Detach()
        {
            this.OnDetached();
            this.AssociatedObject = null;
        }
    }

    /// <summary>
    /// To create a trigger we need to collect some actions and then raise 
    /// the execution when it is required. It is another point we can handle 
    /// with a base class. I will call it Trigger<T>:
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [ContentProperty(Name = "Actions")]
    public abstract class Trigger<T> : Behavior<T>
        where T : DependencyObject
    {
        public Trigger()
        {
            this.Actions = new ActionCollection();
        }

        public ActionCollection Actions
        {
            get;
            private set;
        }

        public void Execute(object sender, object parameter)
        {
            foreach (IAction item in this.Actions)
            {
                item.Execute(sender, parameter);
            }
        }
    }
}
