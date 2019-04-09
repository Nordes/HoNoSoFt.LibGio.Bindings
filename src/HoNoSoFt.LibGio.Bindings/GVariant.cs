using System;
using System.Runtime.InteropServices;

namespace HoNoSoFt.LibGio.Bindings
{
    /// <summary>
    /// https://developer.gnome.org/glib/stable/glib-GVariant.html
    /// </summary>
    public class GVariant
    {
        internal IntPtr ValuePtr { get; private set; }

        internal GVariant(IntPtr gVariant)
        {
            ValuePtr = gVariant;
        }

        // Todo: Add a constructor... many...

        /// <summary>
        /// https://developer.gnome.org/glib/stable/glib-GVariant.html#g-variant-unref
        /// </summary>
        /// <param name="gVariant">Reference to a GVariant to be unref.</param>
        [DllImport("libgio-2.0.so", EntryPoint = "g_variant_unref")]
        public static extern void Unref(IntPtr gVariant);

        /// <summary>
        /// https://developer.gnome.org/glib/stable/glib-GVariant.html#g-variant-ref
        /// </summary>
        /// <param name="gVariant">A GVariant</param>
        [DllImport("libgio-2.0.so", EntryPoint = "g_variant_ref")]
        public static extern IntPtr Ref(IntPtr gVariant);

        /// <summary>
        /// https://developer.gnome.org/glib/stable/glib-GVariant.html#g-variant-ref-sink
        /// </summary>
        /// <param name="gVariantValue">A GVariant</param>
        /// <returns>The same GVariant value</returns>
        [DllImport("libgio-2.0.so", EntryPoint = "g_variant_ref_sink")]
        public static extern IntPtr RefSink(IntPtr gVariantValue);

        /// <summary>
        /// https://developer.gnome.org/glib/stable/glib-GVariant.html#g-variant-is-floating
        /// </summary>
        /// <param name="gVariantValue">A GVariant</param>
        /// <returns>True if the GVariant is floating</returns>
        [DllImport("libgio-2.0.so", EntryPoint = "g_variant_is_floating")]
        public static extern bool IsFloating(IntPtr gVariantValue);

        /// <summary>
        /// https://developer.gnome.org/glib/stable/glib-GVariant.html#g-variant-take-ref
        /// </summary>
        /// <param name="gVariantValue">A GVariant</param>
        /// <returns>The same GVariant value</returns>
        [DllImport("libgio-2.0.so", EntryPoint = "g_variant_take_ref")]
        public static extern bool TakeRef(IntPtr gVariantValue);

        /// <summary>
        /// https://developer.gnome.org/glib/stable/glib-GVariant.html#g-variant-get-type
        /// </summary>
        /// <param name="gVariantValue">A GVariant</param>
        /// <returns>A GVariantType</returns>
        [DllImport("libgio-2.0.so", EntryPoint = "g_variant_get_type")]
        public static extern IntPtr GetType(IntPtr gVariantValue);

        /// <summary>
        /// https://developer.gnome.org/glib/stable/glib-GVariant.html#g-variant-get-type-string
        /// </summary>
        /// <param name="gVariantValue">A GVariant</param>
        /// <returns>the type string for the type of value</returns>
        /// <remarks>Since: 2.24</remarks>
        [DllImport("libgio-2.0.so", EntryPoint = "g_variant_get_type_string")]
        public static extern IntPtr GetTypeString(IntPtr gVariantValue);

        /// <summary>
        /// https://developer.gnome.org/glib/stable/glib-GVariant.html#g-variant-is-of-type
        /// </summary>
        /// <param name="gVariantValue">A GVariant</param>
        /// <param name="gVariantType">A GVariant type</param>
        /// <returns>True if the type of value matches type</returns>
        /// <remarks>Since: 2.24</remarks>
        [DllImport("libgio-2.0.so", EntryPoint = "g_variant_is_of_type")]
        public static extern bool IsOfType(IntPtr gVariantValue, IntPtr gVariantType);

        /// <summary>
        /// https://developer.gnome.org/glib/stable/glib-GVariant.html#g-variant-is-container
        /// </summary>
        /// <param name="gVariantValue">A GVariant</param>
        /// <returns>TRUE if value is a container</returns>
        [DllImport("libgio-2.0.so", EntryPoint = "g_variant_is_container")]
        public static extern bool IsContainer(IntPtr gVariantValue);

        /// <summary>
        /// https://developer.gnome.org/glib/stable/glib-GVariant.html#g-variant-compare
        /// </summary>
        /// <param name="one">A Basic GVariant instance</param>
        /// <param name="two">A GVariant of the same type</param>
        /// <returns>negative value if a &lt; b; zero if a = b; positive value if a &gt; b.</returns>
        /// <remarks>Since 2.26</remarks>
        [DllImport("libgio-2.0.so", EntryPoint = "g_variant_compare")]
        public static extern int Compare(IntPtr one, IntPtr two);

        /// <summary>
        /// https://developer.gnome.org/glib/stable/glib-GVariant.html#g-variant-classify
        /// </summary>
        /// <param name="gVariantValue">A GVariant value</param>
        /// <returns>The GVariantClass of value</returns>
        /// <remarks>Since: 2.24</remarks>
        [DllImport("libgio-2.0.so", EntryPoint = "g_variant_classify")]
        public static extern GVariantClass Classify(IntPtr gVariantValue);

        /// <summary>
        /// https://developer.gnome.org/glib/stable/glib-GVariant.html#g-variant-check-format-string
        /// </summary>
        /// <param name="gVariantValue">A GVariant</param>
        /// <param name="formatString">A valid GVariant format string</param>
        /// <param name="copyOnly">True to ensure the format string make a deep copy</param>
        /// <returns>TRUE if format_string is safe to use.</returns>
        /// <remarks>Since: 2.34</remarks>
        [DllImport("libgio-2.0.so", EntryPoint = "g_variant_check_format_string")]
        public static extern bool CheckFormatString(IntPtr gVariantValue, string formatString, bool copyOnly);

        /// <summary>
        /// https://developer.gnome.org/glib/stable/glib-GVariant.html#g-variant-get
        /// </summary>
        /// <param name="gVariantValue">A GVariant</param>
        /// <param name="formatString">A GVariant format string</param>
        /// <param name="formatParams">Arguments as per format strings</param>
        /// <remarks>Since: 2.24</remarks>
        [DllImport("libgio-2.0.so", EntryPoint = "g_variant_get")]
        public static extern void Get(IntPtr gVariantValue, string formatString, params string[] formatParams);

        ///// https://developer.gnome.org/glib/stable/glib-GVariant.html#g-variant-get-va
        //[DllImport("libgio-2.0.so", EntryPoint = "g_variant_get_va")]
        //public static extern void GetVa...;

        ///// <summary>
        ///// https://developer.gnome.org/glib/stable/glib-GVariant.html#g-variant-new
        ///// </summary>
        ///// <param name="formatString"></param>
        ///// <returns>A GVariant instance</returns>
        //[DllImport("libgio-2.0.so", EntryPoint = "g_variant_new")]
        //public static extern IntPtr New(string formatString, UInt64 someFlags);

        //GVariant *	g_variant_new_va ()

        /// <summary>
        /// https://developer.gnome.org/glib/stable/glib-GVariant.html#g-variant-print
        /// </summary>
        /// <param name="gVariantValue">The GVariant</param>
        /// <param name="typeAnnotate">TRUE if type information should be included in the output</param>
        /// <returns>A newly-allocated string holding the result.</returns>
        [DllImport("libgio-2.0.so", EntryPoint = "g_variant_print")]
        public static extern string Print(IntPtr gVariantValue, bool typeAnnotate);

        //[DllImport("libgio-2.0.so", EntryPoint = "g_variant_print")]
        //public static extern GString PrintString(IntPtr gVariantValue, GString gString, bool typeAnnotate);
        //internal struct GString
        //{
        //    public string str;
        //    public ulong len;
        //    public ulong allocated_len;
        //}

        //        gsize	g_variant_n_children ()
        //        GVariant* g_variant_get_child_value()
        //        void g_variant_get_child()
        //        gsize g_variant_iter_n_children()
        //        GVariantIter* g_variant_iter_new()
        //        GVariant* g_variant_iter_next_value()
        //        gboolean g_variant_iter_next()
        //        gboolean g_variant_iter_loop()

        /*
        GVariant *	g_variant_new_boolean ()
        GVariant *	g_variant_new_byte ()
        GVariant *	g_variant_new_int16 ()
        GVariant *	g_variant_new_uint16 ()
        GVariant *	g_variant_new_int32 ()
        GVariant *	g_variant_new_uint32 ()
        GVariant *	g_variant_new_int64 ()
        GVariant *	g_variant_new_uint64 ()
        GVariant *	g_variant_new_handle ()
        GVariant *	g_variant_new_double ()
        GVariant *	g_variant_new_string ()
        GVariant *	g_variant_new_take_string ()
        GVariant *	g_variant_new_printf ()
        GVariant *	g_variant_new_object_path ()
        gboolean	g_variant_is_object_path ()
        GVariant *	g_variant_new_signature ()
        gboolean	g_variant_is_signature ()
        GVariant *	g_variant_new_variant ()
        GVariant *	g_variant_new_strv ()
        GVariant *	g_variant_new_objv ()
        GVariant *	g_variant_new_bytestring ()
        GVariant *	g_variant_new_bytestring_array ()
        gboolean	g_variant_get_boolean ()
        guint8	g_variant_get_byte ()
        gint16	g_variant_get_int16 ()
        guint16	g_variant_get_uint16 ()
        gint32	g_variant_get_int32 ()
        guint32	g_variant_get_uint32 ()
        gint64	g_variant_get_int64 ()
        guint64	g_variant_get_uint64 ()
        gint32	g_variant_get_handle ()
        gdouble	g_variant_get_double ()
        const gchar *	g_variant_get_string ()
        gchar *	g_variant_dup_string ()
        GVariant *	g_variant_get_variant ()
        const gchar **	g_variant_get_strv ()
        gchar **	g_variant_dup_strv ()
        const gchar **	g_variant_get_objv ()
        gchar **	g_variant_dup_objv ()
        const gchar *	g_variant_get_bytestring ()
        gchar *	g_variant_dup_bytestring ()
        const gchar **	g_variant_get_bytestring_array ()
        gchar **	g_variant_dup_bytestring_array ()
        GVariant *	g_variant_new_maybe ()
        GVariant *	g_variant_new_array ()
        GVariant *	g_variant_new_tuple ()
        GVariant *	g_variant_new_dict_entry ()
        GVariant *	g_variant_new_fixed_array ()
        GVariant *	g_variant_get_maybe ()
        GVariant *	g_variant_lookup_value ()
        gboolean	g_variant_lookup ()
        gconstpointer	g_variant_get_fixed_array ()
        gsize	g_variant_get_size ()
        gconstpointer	g_variant_get_data ()
        GBytes *	g_variant_get_data_as_bytes ()
        void	g_variant_store ()
        GVariant *	g_variant_new_from_data ()
        GVariant *	g_variant_new_from_bytes ()
        GVariant *	g_variant_byteswap ()
        GVariant *	g_variant_get_normal_form ()
        gboolean	g_variant_is_normal_form ()
        guint	g_variant_hash ()
        gboolean	g_variant_equal ()
        GVariantIter *	g_variant_iter_copy ()
        void	g_variant_iter_free ()
        gsize	g_variant_iter_init ()
        #define	G_VARIANT_BUILDER_INIT()
        void	g_variant_builder_unref ()
        GVariantBuilder *	g_variant_builder_ref ()
        GVariantBuilder *	g_variant_builder_new ()
        void	g_variant_builder_init ()
        void	g_variant_builder_clear ()
        void	g_variant_builder_add_value ()
        void	g_variant_builder_add ()
        void	g_variant_builder_add_parsed ()
        GVariant *	g_variant_builder_end ()
        void	g_variant_builder_open ()
        void	g_variant_builder_close ()
        #define	G_VARIANT_DICT_INIT()
        void	g_variant_dict_unref ()
        GVariantDict *	g_variant_dict_ref ()
        GVariantDict *	g_variant_dict_new ()
        void	g_variant_dict_init ()
        void	g_variant_dict_clear ()
        gboolean	g_variant_dict_contains ()
        gboolean	g_variant_dict_lookup ()
        GVariant *	g_variant_dict_lookup_value ()
        void	g_variant_dict_insert ()
        void	g_variant_dict_insert_value ()
        gboolean	g_variant_dict_remove ()
        GVariant *	g_variant_dict_end ()
        GVariant *	g_variant_parse ()
        GVariant *	g_variant_new_parsed_va ()
        GVariant *	g_variant_new_parsed ()
        gchar *	g_variant_parse_error_print_context ()
        */
    }
}
