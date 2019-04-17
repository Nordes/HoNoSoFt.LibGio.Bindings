using System.ComponentModel;

namespace HoNoSoFt.LibGio.Bindings.GEnums
{
    internal enum GDBusError
    {
        [Description("A generic error; \"something went wrong\" - see the error message for more.")]
        G_DBUS_ERROR_FAILED,

        [Description("There was not enough memory to complete an operation.")]
        G_DBUS_ERROR_NO_MEMORY,

        [Description("The bus doesn't know how to launch a service to supply the bus name you wanted.")]
        G_DBUS_ERROR_SERVICE_UNKNOWN,

        [Description("The bus name you referenced doesn't exist (i.e. no application owns it).")]
        G_DBUS_ERROR_NAME_HAS_NO_OWNER,

        [Description("No reply to a message expecting one, usually means a timeout occurred.")]
        G_DBUS_ERROR_NO_REPLY,

        [Description("Something went wrong reading or writing to a socket, for example.")]
        G_DBUS_ERROR_IO_ERROR,

        [Description("A D-Bus bus address was malformed.")]
        G_DBUS_ERROR_BAD_ADDRESS,

        [Description("Requested operation isn't supported (like ENOSYS on UNIX).")]
        G_DBUS_ERROR_NOT_SUPPORTED,

        [Description("Some limited resource is exhausted.")]
        G_DBUS_ERROR_LIMITS_EXCEEDED,

        [Description("Security restrictions don't allow doing what you're trying to do.")]
        G_DBUS_ERROR_ACCESS_DENIED,

        [Description("Authentication didn't work.")]
        G_DBUS_ERROR_AUTH_FAILED,

        [Description("Unable to connect to server (probably caused by ECONNREFUSED on a socket).")]
        G_DBUS_ERROR_NO_SERVER,

        [Description("Certain timeout errors, possibly ETIMEDOUT on a socket. Note that G_DBUS_ERROR_NO_REPLY is used for message reply timeouts. Warning: this is confusingly-named given that G_DBUS_ERROR_TIMED_OUT also exists. We can't fix it for compatibility reasons so just be careful.")]
        G_DBUS_ERROR_TIMEOUT,

        [Description("No network access (probably ENETUNREACH on a socket).")]
        G_DBUS_ERROR_NO_NETWORK,

        [Description("Can't bind a socket since its address is in use (i.e. EADDRINUSE).")]
        G_DBUS_ERROR_ADDRESS_IN_USE,

        [Description("The connection is disconnected and you're trying to use it.")]
        G_DBUS_ERROR_DISCONNECTED,

        [Description("Invalid arguments passed to a method call.")]
        G_DBUS_ERROR_INVALID_ARGS,

        [Description("Missing file.")]
        G_DBUS_ERROR_FILE_NOT_FOUND,

        [Description("Existing file and the operation you're using does not silently overwrite.")]
        G_DBUS_ERROR_FILE_EXISTS,

        [Description("Method name you invoked isn't known by the object you invoked it on.")]
        G_DBUS_ERROR_UNKNOWN_METHOD,

        [Description("Certain timeout errors, e.g. while starting a service. Warning: this is confusingly-named given that G_DBUS_ERROR_TIMEOUT also exists. We can't fix it for compatibility reasons so just be careful.")]
        G_DBUS_ERROR_TIMED_OUT,

        [Description("Tried to remove or modify a match rule that didn't exist.")]
        G_DBUS_ERROR_MATCH_RULE_NOT_FOUND,

        [Description("The match rule isn't syntactically valid.")]
        G_DBUS_ERROR_MATCH_RULE_INVALID,

        [Description("While starting a new process, the exec() call failed.")]
        G_DBUS_ERROR_SPAWN_EXEC_FAILED,

        [Description("While starting a new process, the fork() call failed.")]
        G_DBUS_ERROR_SPAWN_FORK_FAILED,

        [Description("While starting a new process, the child exited with a status code.")]
        G_DBUS_ERROR_SPAWN_CHILD_EXITED,

        [Description("While starting a new process, the child exited on a signal.")]
        G_DBUS_ERROR_SPAWN_CHILD_SIGNALED,

        [Description("While starting a new process, something went wrong.")]
        G_DBUS_ERROR_SPAWN_FAILED,

        [Description("We failed to setup the environment correctly.")]
        G_DBUS_ERROR_SPAWN_SETUP_FAILED,

        [Description("We failed to setup the config parser correctly.")]
        G_DBUS_ERROR_SPAWN_CONFIG_INVALID,

        [Description("Bus name was not valid.")]
        G_DBUS_ERROR_SPAWN_SERVICE_INVALID,

        [Description("Service file not found in system-services directory.")]
        G_DBUS_ERROR_SPAWN_SERVICE_NOT_FOUND,

        [Description("Permissions are incorrect on the setuid helper.")]
        G_DBUS_ERROR_SPAWN_PERMISSIONS_INVALID,

        [Description("Service file invalid (Name, User or Exec missing).")]
        G_DBUS_ERROR_SPAWN_FILE_INVALID,

        [Description("Tried to get a UNIX process ID and it wasn't available.")]
        G_DBUS_ERROR_SPAWN_NO_MEMORY,

        [Description("Tried to get a UNIX process ID and it wasn't available.")]
        G_DBUS_ERROR_UNIX_PROCESS_ID_UNKNOWN,

        [Description("A type signature is not valid.")]
        G_DBUS_ERROR_INVALID_SIGNATURE,

        [Description("A file contains invalid syntax or is otherwise broken.")]
        G_DBUS_ERROR_INVALID_FILE_CONTENT,

        [Description("Asked for SELinux security context and it wasn't available.")]
        G_DBUS_ERROR_SELINUX_SECURITY_CONTEXT_UNKNOWN,

        [Description("Asked for ADT audit data and it wasn't available.")]
        G_DBUS_ERROR_ADT_AUDIT_DATA_UNKNOWN,

        [Description("There's already an object with the requested object path.")]
        G_DBUS_ERROR_OBJECT_PATH_IN_USE,

        [Description("Object you invoked a method on isn't known. Since 2.42")]
        G_DBUS_ERROR_UNKNOWN_OBJECT,

        [Description("Interface you invoked a method on isn't known by the object. Since 2.42")]
        G_DBUS_ERROR_UNKNOWN_INTERFACE,

        [Description("Property you tried to access isn't known by the object. Since 2.42")]
        G_DBUS_ERROR_UNKNOWN_PROPERTY,

        [Description("Property you tried to set is read-only. Since 2.42")]
        G_DBUS_ERROR_PROPERTY_READ_ONLY,
    }
}
