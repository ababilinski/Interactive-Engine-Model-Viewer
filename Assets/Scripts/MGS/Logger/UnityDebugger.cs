/*************************************************************************
 *  Copyright © 2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  UnityDebugger.cs
 *  Description  :  Debugger for unity editor.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  9/19/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.Common.DesignPattern;
using UnityEngine;

namespace MGS.Logger
{
    /// <summary>
    /// Debugger for unity editor.
    /// </summary>
    public sealed class UnityDebugger : Singleton<UnityDebugger>, Common.Logger.ILogger
    {
        #region Private Method
        /// <summary>
        /// Constructor.
        /// </summary>
        private UnityDebugger() { }
        #endregion

        #region Public Method
        /// <summary>
        /// Logs a formatted message.
        /// </summary>
        /// <param name="level">Level of log message.</param>
        /// <param name="format">A composite format string.</param>
        /// <param name="args">Format arguments.</param>
        public void Log(int level, string format, params object[] args)
        {
            Debug.LogFormat(format, args);
        }

        /// <summary>
        /// Logs a formatted error message.
        /// </summary>
        /// <param name="level">Level of error message.</param>
        /// <param name="format">A composite format string.</param>
        /// <param name="args">Format arguments.</param>
        public void LogError(int level, string format, params object[] args)
        {
            Debug.LogErrorFormat(format, args);
        }

        /// <summary>
        /// Logs a formatted warning message.
        /// </summary>
        /// <param name="level">Level of warning message.</param>
        /// <param name="format">A composite format string.</param>
        /// <param name="args">Format arguments.</param>
        public void LogWarning(int level, string format, params object[] args)
        {
            Debug.LogWarningFormat(format, args);
        }
        #endregion
    }
}