namespace Buoi3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhachHang")]
    public partial class KhachHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KhachHang()
        {
            DonHangs = new HashSet<DonHang>();
        }

        [Key]
        public int makh { get; set; }

        [StringLength(50)]
        [Display (Name="Họ Tên")]
        public string hoten { get; set; }

        [StringLength(20)]
        [Display (Name ="Tên Đăng Nhập")]
        public string tendangnhap { get; set; }

        [StringLength(10)]
        [Display(Name ="Mật Khẩu")]
        public string matkhau { get; set; }

        [StringLength(50)]
        [Display(Name ="Địa Chỉ Email")]
        public string email { get; set; }

        [StringLength(100)]
        [Display(Name ="Địa Chỉ")]
        public string diachi { get; set; }

        [StringLength(15)]
        [Display(Name ="Số Điện Thoại")]
        public string dienthoai { get; set; }

        [Column(TypeName = "date")]
        [Display(Name ="Ngày Sinh")]
        public DateTime? ngaysinh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DonHang> DonHangs { get; set; }
    }
}
