using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Navigation;
using Abp.Localization;

namespace ESLab.SPMS.Web
{
    /// <summary>
    /// This class defines menus for the application.
    /// It uses ABP's menu system.
    /// When you add menu items here, they are automatically appear in angular application.
    /// See .cshtml and .js files under App/Main/views/layout/header to know how to render menu.
    /// </summary>
    public class SPMSNavigationProvider : NavigationProvider
    {

        public override void SetNavigation(INavigationProviderContext context)
        {
            context.Manager.MainMenu
                .AddItem(
                    new MenuItemDefinition(
                        "Home",
                        new LocalizableString("HomePage", SPMSConsts.LocalizationSourceName),
                        url: "#/",
                        icon: "fa fa-home"
                        )
                ).AddItem(
                    new MenuItemDefinition(
                        "Settings",
                        new LocalizableString("Settings", SPMSConsts.LocalizationSourceName),
                        icon: "fa fa-cogs"
                        ).AddItem(
                            new MenuItemDefinition(
                            "Brands",
                            new LocalizableString("Brands", SPMSConsts.LocalizationSourceName),
                            url: "#/brands",
                            icon: "fa fa-cog"
                            )
                        ).AddItem(
                            new MenuItemDefinition(
                            "Distributors",
                            new LocalizableString("Distributors", SPMSConsts.LocalizationSourceName),
                            url: "#/Distributors",
                            icon: "fa fa-cog"
                            )
                        ).AddItem(
                            new MenuItemDefinition(
                            "FinishProducts",
                            new LocalizableString("FinishProducts", SPMSConsts.LocalizationSourceName),
                            url: "#/FinishProducts",
                            icon: "fa fa-cog"
                            )
                        ).AddItem(
                            new MenuItemDefinition(
                            "Freights",
                            new LocalizableString("Freights", SPMSConsts.LocalizationSourceName),
                            url: "#/freights",
                            icon: "fa fa-cog"
                            )
                        ).AddItem(
                            new MenuItemDefinition(
                            "ProductGrades",
                            new LocalizableString("ProductGrades", SPMSConsts.LocalizationSourceName),
                            url: "#/productGrades",
                            icon: "fa fa-cog"
                            )
                       ).AddItem(
                            new MenuItemDefinition(
                            "ProductCategories",
                            new LocalizableString("ProductCategories", SPMSConsts.LocalizationSourceName),
                            url: "#/productCategories",
                            icon: "fa fa-cog"
                            )
                        ).AddItem(
                            new MenuItemDefinition(
                            "ProductUnits",
                            new LocalizableString("ProductUnits", SPMSConsts.LocalizationSourceName),
                            url: "#/ProductUnits",
                            icon: "fa fa-cog"
                            )
                        ).AddItem(
                            new MenuItemDefinition(
                            "ProductApis",
                            new LocalizableString("ProductApis", SPMSConsts.LocalizationSourceName),
                            url: "#/ProductApis",
                            icon: "fa fa-cog"
                            )
                        ).AddItem(
                            new MenuItemDefinition(
                            "RawMaterialTypes",
                            new LocalizableString("RawMaterialTypes", SPMSConsts.LocalizationSourceName),
                            url: "#/RawMaterialTypes",
                            icon: "fa fa-cog"
                            )
                        ).AddItem(
                            new MenuItemDefinition(
                            "RawMaterials",
                            new LocalizableString("RawMaterials", SPMSConsts.LocalizationSourceName),
                            url: "#/RawMaterials",
                            icon: "fa fa-cog"
                            )
                        ).AddItem(
                            new MenuItemDefinition(
                            "Vendors",
                            new LocalizableString("Vendors", SPMSConsts.LocalizationSourceName),
                            url: "#/vendors",
                            icon: "fa fa-cog"
                            )
                        ).AddItem(
                            new MenuItemDefinition(
                            "FinishProductList",
                            new LocalizableString("FinishProductList", SPMSConsts.LocalizationSourceName),
                            url: "#/FinishProductList",
                            icon: "fa fa-cog"
                            )
                        )
                        .AddItem(
                            new MenuItemDefinition(
                            "Warehouses",
                            new LocalizableString("Warehouses", SPMSConsts.LocalizationSourceName),
                            url: "#/Warehouses",
                            icon: "fa fa-cog"
                            )
                        ).AddItem(
                            new MenuItemDefinition(
                            "Zones",
                            new LocalizableString("Zones", SPMSConsts.LocalizationSourceName),
                            url: "#/zones",
                            icon: "fa fa-cog"
                            )
                        )
                    )
                    .AddItem(
                    new MenuItemDefinition(
                        "Purchase",
                        new LocalizableString("Purchase", SPMSConsts.LocalizationSourceName),
                        icon: "fa fa-shopping-cart"
                        ).AddItem(
                            new MenuItemDefinition(
                            "CreatePurchase",
                            new LocalizableString("CreatePurchase", SPMSConsts.LocalizationSourceName),
                            url: "#/purchase/new",
                            icon: "fa fa-plus"
                            )
                        ).AddItem(
                            new MenuItemDefinition(
                            "PurchaseList",
                            new LocalizableString("PurchaseList", SPMSConsts.LocalizationSourceName),
                            url: "#/purchase/list",
                            icon: "fa fa-list"
                            )
                        )
                ).AddItem(
                    new MenuItemDefinition(
                        "Inventory",
                        new LocalizableString("Inventory", SPMSConsts.LocalizationSourceName),
                        icon: "fa fa-cart-arrow-down"
                        ).AddItem(
                            new MenuItemDefinition(
                            "StockReceive",
                            new LocalizableString("StockReceive", SPMSConsts.LocalizationSourceName),
                            url: "#/stock/openpurchases",
                            icon: "fa fa-cart-plus"
                            )
                        )
                ).AddItem(
                     new MenuItemDefinition(
                        "Production",
                        new LocalizableString("Production", SPMSConsts.LocalizationSourceName),
                        icon: "fa fa-industry"
                        ).AddItem(
                            new MenuItemDefinition(
                            "NewFinishProduct",
                            new LocalizableString("NewFinishProduct", SPMSConsts.LocalizationSourceName),
                            url: "#/product/new",
                            icon: "fa fa-plus-circle"
                            )
                        )

                ).AddItem(
                    new MenuItemDefinition(
                        "Sales",
                        new LocalizableString("Sales", SPMSConsts.LocalizationSourceName),
                        icon: "fa fa-cart-arrow-down"
                        )
                ).AddItem(
                    new MenuItemDefinition(
                        "Finance",
                        new LocalizableString("Finance", SPMSConsts.LocalizationSourceName),
                        icon: "fa fa-cart-arrow-down"
                        )
                );

        }
    }
}
