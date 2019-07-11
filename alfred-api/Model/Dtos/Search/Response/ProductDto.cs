using System;
using System.Collections.Generic;

namespace alfred_api.Model.Dtos.Search.Response
{
    public class ProductsDto
    {
        public IList<ProductDto> Products { get; set; }
        public int TotalItems { get; set; }


        public class ProductDto
        {
            public Productindexmodel ProductIndexModel { get; set; }
            public Linksviewmodel LinksViewModel { get; set; }
            public bool ShouldDisplayAbReviews { get; set; }
            public object Components { get; set; }
            public Visibleproperty[] VisibleProperties { get; set; }
            public object[] EligibleDomains { get; set; }
            public bool IsAbcamRecommendsProduct { get; set; }

            public class Productindexmodel
            {
                public int Id { get; set; }
                public string ProductCode { get; set; }
                public string ProductName { get; set; }
                public string ProductNameOrdering { get; set; }
                public string ProductDescription { get; set; }
                public string ProductNameHtml { get; set; }
                public string ProductDescriptionHtml { get; set; }
                public string ProductType { get; set; }
                public int ProductTypeId { get; set; }
                public int ProductSubtypeId { get; set; }
                public object BiologicalActivity { get; set; }
                public string[] AlternativeName { get; set; }
                public string TargetName { get; set; }
                public object CloneNumber { get; set; }
                public string Isotype { get; set; }
                public string HostSpecies { get; set; }
                public object SpeciesOfOrigin { get; set; }
                public string Conjugate { get; set; }
                public object ConjugateColor { get; set; }
                public object Emission { get; set; }
                public object Excitation { get; set; }
                public object ExpressionSystem { get; set; }
                public string[] Application { get; set; }
                public string[] ApplicationFullForm { get; set; }
                public object SampleType { get; set; }
                public string[] Images { get; set; }
                public string[] Reactivity { get; set; }
                public object PredictedReactivity { get; set; }
                public object Purity { get; set; }
                public object FormerProductCode { get; set; }
                public object AssayDuration { get; set; }
                public object Platform { get; set; }
                public object DetectionMethod { get; set; }
                public object BrandLogoUrlForSearchResult { get; set; }
                public bool ShowBrandOnEnglishDomain { get; set; }
                public bool ShowBrandOnJapanDomain { get; set; }
                public bool ShowBrandOnChinaDomain { get; set; }
                public object Brand { get; set; }
                public int StarRating { get; set; }
                public int ReviewCount { get; set; }
                public bool CanReviewProduct { get; set; }
                public int ReferenceCount { get; set; }
                public string DatasheetLink { get; set; }
                public object Tag { get; set; }
                public object CountriesTrialSizesAppliesTo { get; set; }
                public object Nature { get; set; }
                public object KnockoutValidated { get; set; }
                public object Recombinant { get; set; }
                public object AssayType { get; set; }
                public string[] ImmunogenSpecies { get; set; }
                public object Specificity { get; set; }
                public string Clonality { get; set; }
                public string[] Modification { get; set; }
                public object PreAdsorbed { get; set; }
                public object Accession { get; set; }
                public int QualityScore { get; set; }
                public string PredictedReactivityFormatted { get; set; }
                public bool ShowReviewTab { get; set; }
                public DateTime FirstPublished { get; set; }
                public bool IsNewProduct { get; set; }
            }

            public class Linksviewmodel
            {
                public string DatasheetLink { get; set; }
                public string DatasheetAbReviewLink { get; set; }
                public string DatasheetReferencesLink { get; set; }
            }

            public class Visibleproperty
            {
                public int Id { get; set; }
                public int ProductTypeId { get; set; }
                public int PageName { get; set; }
                public string PropertyName { get; set; }
                public int DisplayOrder { get; set; }
            }
        }
    }
}