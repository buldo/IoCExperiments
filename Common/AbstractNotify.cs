using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    using System.ComponentModel;
    using System.Linq.Expressions;

    public class AbstractNotify : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged Members
        /// <summary>
        /// Событие "Изменилось значение свойства".
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Оповестить об изменении значения свойства.
        /// </summary>
        /// <param name="propertyName">Имя изменившегося свойства.</param>
        protected void OnPropertyChanged(string propertyName)
        {
            var args = new PropertyChangedEventArgs(propertyName);
            if (PropertyChanged != null)
            {
                PropertyChanged(this, args);
            }
        }

        /// <summary>
        /// Notify Property Changed
        /// </summary>
        /// <typeparam name="T">Не используется</typeparam>
        /// <param name="expression">Просто для получения имени</param>
        protected virtual void OnPropertyChanged<T>(Expression<Func<T>> expression)
        {
            var propertyName = GetPropertyName(expression);
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /// <summary>
        /// The get property name.
        /// </summary>
        /// <param name="expression">
        /// The expression.
        /// </param>
        /// <typeparam name="T">
        /// Тип. Не используется
        /// </typeparam>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        protected string GetPropertyName<T>(Expression<Func<T>> expression)
        {
            var memberExpression = (MemberExpression)expression.Body;
            return memberExpression.Member.Name;
        }
        #endregion INotifyPropertyChanged Members
    }
}
