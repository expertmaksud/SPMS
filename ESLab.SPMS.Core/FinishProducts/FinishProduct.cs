using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ESLab.SPMS.Brands;
using ESLab.SPMS.FinishProductFormulas;
using ESLab.SPMS.ProductApis;
using ESLab.SPMS.ProductCategories;
using ESLab.SPMS.ProductGrades;
using ESLab.SPMS.ProductUnits;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ESLab.SPMS.FinishProducts
{
    public class FinishProduct : Entity, IFullAudited
    {

        [Index(IsUnique = true)]
        [StringLength(100)]
        public virtual string ProductName { get; set; }

        [ForeignKey("BrandId")]        
        public virtual Brand Brand { get; set; }
        public virtual int BrandId { get; set; }

        [ForeignKey("ProductGradeId")]
        public virtual ProductGrade ProductGrade { get; set; }
        public virtual int ProductGradeId { get; set; }

        [ForeignKey("ProductApiId")]
        public virtual ProductApi ProductApi { get; set; }
        public virtual int ProductApiId { get; set; }

        [ForeignKey("ProductCategoryId")]
        public virtual ProductCategory ProductCategory { get; set; }
        public virtual int ProductCategoryId { get; set; }

        public virtual int PackSize { get; set; }

        public virtual int Multiplier { get; set; }

        [ForeignKey("ProductUnitId")]
        public virtual ProductUnit ProductUnit { get; set; }
        public virtual int ProductUnitId { get; set; }

        public virtual decimal Mrp { get; set; }

        public virtual float ReOrderPoint { get; set; }

        public virtual DateTime CreationTime { get; set; }

        public long? CreatorUserId { get; set; }

        public DateTime? LastModificationTime { get; set; }

        public long? LastModifierUserId { get; set; }

        public long? DeleterUserId { get; set; }

        public DateTime? DeletionTime { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ICollection<FinishProductFormula> FinishProductFormulaItems { get; set; }

        public FinishProduct()
        {
            CreationTime = DateTime.Now;
        }
    }
}
