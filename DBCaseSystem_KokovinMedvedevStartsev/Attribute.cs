//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DBCaseSystem_KokovinMedvedevStartsev
{
    using System;
    using System.Collections.Generic;
    
    public partial class Attribute
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string IsNull { get; set; }
        public string IsKey { get; set; }
        public string Length { get; set; }
        public string DefaultValue { get; set; }
        public string Indexed { get; set; }
    
        public virtual Table Table { get; set; }
    }
}
