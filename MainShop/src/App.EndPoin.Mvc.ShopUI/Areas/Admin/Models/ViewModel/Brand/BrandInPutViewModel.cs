using System.ComponentModel.DataAnnotations;

public class BrandInPutViewModel
{
    [Display(Name ="ترتیب نمایش")]
    [Required(ErrorMessage ="تعیین ترتیب نمایش اجباری است")]
    [Range(1,5,ErrorMessage ="مقدار باید بین 1 تا 5 باشد")]
    public int DisplayOrder { get; set; }

    [Display(Name = " نام برند")]
    [Required(ErrorMessage = "تکمیل فیلد نام برند اجباری است")]
    public string Name { get; set; } = null!;

    [Display(Name = " تکرار نام برند")]
    [Required(ErrorMessage = "تکمیل فیلد تکرار نام برند اجباری است")]
    [Compare(nameof(Name),ErrorMessage ="نام برند بدرستی وارد نشده است")]
    public string ConfirmName { get; set; } = null!;

}