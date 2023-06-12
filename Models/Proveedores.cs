
public class Proveedores
{
    [Key]
    public int ProveedorId { get; set; }
    [Required(ErrorMessage = "Ingrese el nombre del proveedor.")]
    public string Nombre { get; set; } = string.Empty;
    [Required(ErrorMessage = "Ingrese el RNC del proveedor.")]
    public string RNC { get; set; } = string.Empty;
    [Required(ErrorMessage = "Ingrese el NCF del proveedor.")]
    public string NCF { get; set; } = string.Empty;
    [DataType(DataType.Date)]
    public DateOnly Fecha { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    [Required(ErrorMessage = "Ingrese una dirección.")]
    public string Direccion { get; set; } = string.Empty;
    [Required(ErrorMessage = "El email es requerido.")]
    [RegularExpression("\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*",ErrorMessage = "Formato inválido. name@gmail.com")]
    public string Email { get; set; } = string.Empty;
    [Required(ErrorMessage = "Ingrese un número teléfonico.")]
    [RegularExpression(@"^\d{3}[- ]?\d{3}[- ]?\d{4}$",ErrorMessage = "Formato inválido. 000-000-0000")]
    public string Telefono { get; set; } = string.Empty;
    public bool EsVisible { get; set; } = false;
}