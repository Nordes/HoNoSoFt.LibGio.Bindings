﻿using System.ComponentModel;

namespace HoNoSoFt.LibGio.Bindings.GEnums
{
    /// <summary>
    /// ref: https://github.com/ImageMagick/glib/blob/master/glib/gfileutils.h
    /// </summary>
    internal enum GFileError
    {
        [Description("Operation not permitted; only the owner of the file (or other resource) or processes with special privileges can perform the operation.")]
        G_FILE_ERROR_EXIST,
        [Description("File is a directory; you cannot open a directory for writing, or create or remove hard links to it.")]
        G_FILE_ERROR_ISDIR,
        [Description("Permission denied; the file permissions do not allow the attempted operation.")]
        G_FILE_ERROR_ACCES,
        [Description("Filename too long.")]
        G_FILE_ERROR_NAMETOOLONG,
        [Description("No such file or directory. This is a \"file doesn't exist\" error for ordinary files that are referenced in contexts where they are expected to already exist.")]
        G_FILE_ERROR_NOENT,
        [Description("A file that isn't a directory was specified when a directory is required.")]
        G_FILE_ERROR_NOTDIR,
        [Description("No such device or address. The system tried to use the device represented by a file you specified, and it couldn't find the device. This can mean that the device file was installed incorrectly, or that the physical device is missing or not correctly attached to the computer.")]
        G_FILE_ERROR_NXIO,
        [Description("The underlying file system of the specified file does not support memory mapping.")]
        G_FILE_ERROR_NODEV,
        [Description("The directory containing the new link can't be modified because it's on a read-only file system.")]
        G_FILE_ERROR_ROFS,
        [Description("Text file busy.")]
        G_FILE_ERROR_TXTBSY,
        [Description("You passed in a pointer to bad memory. (GLib won't reliably return this, don't pass in pointers to bad memory.)")]
        G_FILE_ERROR_FAULT,
        [Description("Too many levels of symbolic links were encountered in looking up a file name. This often indicates a cycle of symbolic links.")]
        G_FILE_ERROR_LOOP,
        [Description("No space left on device; write operation on a file failed because the disk is full.")]
        G_FILE_ERROR_NOSPC,
        [Description("No memory available. The system cannot allocate more virtual memory because its capacity is full.")]
        G_FILE_ERROR_NOMEM,
        [Description("The current process has too many files open and can't open any more. Duplicate descriptors do count toward this limit.")]
        G_FILE_ERROR_MFILE,
        [Description("There are too many distinct file openings in the entire system.")]
        G_FILE_ERROR_NFILE,
        [Description("Bad file descriptor; for example, I/O on a descriptor that has been closed or reading from a descriptor open only for writing (or vice versa).")]
        G_FILE_ERROR_BADF,
        [Description("Invalid argument. This is used to indicate various kinds of problems with passing the wrong argument to a library function.")]
        G_FILE_ERROR_INVAL,
        [Description("Broken pipe; there is no process reading from the other end of a pipe. Every library function that returns this error code also generates a 'SIGPIPE' signal; this signal terminates the program if not handled or blocked. Thus, your program will never actually see this code unless it has handled or blocked 'SIGPIPE'.")]
        G_FILE_ERROR_PIPE,
        [Description("Resource temporarily unavailable; the call might work if you try again later.")]
        G_FILE_ERROR_AGAIN,
        [Description("Interrupted function call; an asynchronous signal occurred and prevented completion of the call. When this happens, you should try the call again.")]
        G_FILE_ERROR_INTR,
        [Description("Input/output error; usually used for physical read or write errors. i.e. the disk or other physical device hardware is returning errors.")]
        G_FILE_ERROR_IO,
        [Description("Operation not permitted; only the owner of the file (or other resource) or processes with special privileges can perform the operation.")]
        G_FILE_ERROR_PERM,
        [Description("Function not implemented; this indicates that the system is missing some functionality.")]
        G_FILE_ERROR_NOSYS,
        [Description("Does not correspond to a UNIX error code; this is the standard \"failed for unspecified reason\" error code present in all GError error code enumerations. Returned if no specific code applies.")]
        G_FILE_ERROR_FAILED
    }
}
