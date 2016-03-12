using Elmah;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Model.Base
{
    [Serializable]
    public class ActionConfirmation
    {
        #region Constructor
        /// <summary>
        /// Prevents a default instance of the ActionConfirmation class from being created
        /// </summary>
        private ActionConfirmation()
        {
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets a value indicating whether WasSuccessful
        /// </summary>
        public bool WasSuccessful { get; private set; }

        /// <summary>
        /// Gets or sets a Message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets a Value
        /// </summary>
        public object Value { get; set; }
        #endregion

        #region Public Methods
        /// <summary>
        /// Creates a success message
        /// </summary>
        /// <param name="message">
        /// the message
        /// </param>
        /// <returns>
        /// an ActionConfirmation
        /// </returns>
        public static ActionConfirmation CreateSuccessConfirmation(string message)
        {
            return new ActionConfirmation { Message = message, WasSuccessful = true };
        }

        /// <summary>
        /// Creates a success message
        /// </summary>
        /// <param name="value">
        /// the return value
        /// </param>
        /// <returns>
        /// an ActionConfirmation
        /// </returns>
        public static ActionConfirmation CreateSuccessConfirmation(object value)
        {
            return new ActionConfirmation { Value = value, WasSuccessful = true };
        }

        /// <summary>
        /// Creates a failure message
        /// </summary>
        /// <param name="message">
        /// the message
        /// </param>
        /// <returns>
        /// an ActionConfirmation
        /// </returns>
        public static ActionConfirmation CreateFailureConfirmation(string message)
        {
            ErrorSignal.FromCurrentContext().Raise(new Elmah.ApplicationException(message));
            return new ActionConfirmation { Message = message, WasSuccessful = false };
        }
        #endregion
    }
}
