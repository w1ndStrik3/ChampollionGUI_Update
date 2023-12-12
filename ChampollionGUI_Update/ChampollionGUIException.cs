using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChampollionGUI_Update
{
    
    [Serializable]
    public class ChampollionGUIException : Exception
    {
        
        public ChampollionGUIException(String ErrorMessage) 
            : base(ErrorMessage)
        { }
    }

    //************************************************************************
    /// <summary>
    /// The class represents an exception that is thrown to indicate that not
    /// all conditions were satisfied for the program to start the process of
    /// decompiling the .pex files. In most cases, it is thrown when there is
    /// an issue with a folder that the user has specified.
    /// </summary>
    //************************************************************************
    public class PreDecompilationException : ChampollionGUIException
    {
        //************************************************************************
        /// <summary>
        /// A new exception is constructed with the error message errorMessage.
        /// </summary>
        /// <param name="errorMessage">
        /// The error message of the exception.
        /// </param>
        //************************************************************************
        public PreDecompilationException(String ErrorMessage)
            : base(ErrorMessage)
        { }
    }

    //************************************************************************
    /// <summary>
    /// The class represents an exception that is thrown to indicate that the
    /// decompilation process ran into an error during excecution ( In most cases, it is thrown when there is
    /// an issue with a folder that the user has specified.
    /// </summary>
    //************************************************************************
    public class IntraDecompilationException : ChampollionGUIException
    {
        //************************************************************************
        /// <summary>
        /// A new exception is constructed with the error message errorMessage.
        /// </summary>
        /// <param name="errorMessage">
        /// The error message of the exception.
        /// </param>
        //************************************************************************
        public IntraDecompilationException(String ErrorMessage)
            : base(ErrorMessage)
        { }
    }
}
