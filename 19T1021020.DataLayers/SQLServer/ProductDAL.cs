using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _19T1021020.DomainModels;

namespace _19T1021020.DataLayers.SQLServer
{
    /// <summary>
    /// Cài đặt chức năng xử lý dữ liệu liên quan đến mặt hàng
    /// </summary>
    public class ProductDAL : _BaseDAL, IProductDAL
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString"></param>
        public ProductDAL(string connectionString) : base(connectionString)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public int Add(Product data)
        {
            int productId;

            // Add product to database
            using (var connection = OpenConnection())
            {
                var sqlCommand = connection.CreateCommand();
                sqlCommand.CommandText =
                    @"INSERT INTO Products (ProductName, SupplierID, CategoryID, Unit, Price, Photo) VALUES (@ProductName, @SupplierID, @CategoryID, @Unit, @Price, @Photo); SELECT @@IDENTITY;";
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@ProductName", data.ProductName);
                sqlCommand.Parameters.AddWithValue("@SupplierID", data.SupplierID);
                sqlCommand.Parameters.AddWithValue("@CategoryID", data.CategoryID);
                sqlCommand.Parameters.AddWithValue("@Unit", data.Unit);
                sqlCommand.Parameters.AddWithValue("@Price", data.Price);
                sqlCommand.Parameters.AddWithValue("@Photo", data.Photo);

                productId = Convert.ToInt32(sqlCommand.ExecuteScalar());
                connection.Close();
            }

            return productId;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public long AddAttribute(ProductAttribute data)
        {
            long attributeId;

            // Add attribute to database
            using (var connection = OpenConnection())
            {
                var sqlCommand = connection.CreateCommand();
                sqlCommand.CommandText = "INSERT INTO ProductAttributes (ProductID, AttributeName, AttributeValue, DisplayOrder) VALUES (@ProductID, @AttributeName, @AttributeValue, @DisplayOrder); SELECT @@IDENTITY;";
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@ProductID", data.ProductID);
                sqlCommand.Parameters.AddWithValue("@AttributeName", data.AttributeName);
                sqlCommand.Parameters.AddWithValue("@AttributeValue", data.AttributeValue);
                sqlCommand.Parameters.AddWithValue("@DisplayOrder", data.DisplayOrder);

                attributeId = Convert.ToInt64(sqlCommand.ExecuteScalar());
                connection.Close();
            }

            return attributeId;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public long AddPhoto(ProductPhoto data)
        {
            long photoId;

            // Add photo to database
            using (var connection = OpenConnection())
            {
                var sqlCommand = connection.CreateCommand();
                sqlCommand.CommandText = "INSERT INTO ProductPhotos (ProductID, Photo, Description, DisplayOrder, IsHidden) VALUES (@ProductID, @Photo, @Description, @DisplayOrder, @IsHidden); SELECT @@IDENTITY;";
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@ProductID", data.ProductID);
                sqlCommand.Parameters.AddWithValue("@Photo", data.Photo);
                sqlCommand.Parameters.AddWithValue("@Description", data.Description);
                sqlCommand.Parameters.AddWithValue("@DisplayOrder", data.DisplayOrder);
                sqlCommand.Parameters.AddWithValue("@IsHidden", data.IsHidden);

                photoId = Convert.ToInt64(sqlCommand.ExecuteScalar());
                connection.Close();
            }

            return photoId;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchValue"></param>
        /// <param name="categoryID"></param>
        /// <param name="supplierID"></param>
        /// <returns></returns>
        public int Count(string searchValue = "", int categoryID = 0, int supplierID = 0)
        {
            int totalRows;

            // Read total rows from database
            using (var connection = OpenConnection())
            {
                var sqlCommand = connection.CreateCommand();
                sqlCommand.CommandText =
                    @"SELECT COUNT(*) FROM Products WHERE ((@SearchValue = N'') OR (ProductName LIKE @SearchValue)) AND ((@CategoryId = 0) OR(CategoryID = @CategoryId)) AND ((@SupplierId = 0) OR (SupplierID = @SupplierId));";
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@SearchValue", "%" + searchValue + "%");
                sqlCommand.Parameters.AddWithValue("@CategoryId", categoryID);
                sqlCommand.Parameters.AddWithValue("@SupplierId", supplierID);

                totalRows = Convert.ToInt32(sqlCommand.ExecuteScalar());
                connection.Close();
            }

            return totalRows;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="productID"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool Delete(int productID)
        {
            bool result;

            // Delete product from database
            using (var connection = OpenConnection())
            {
                var sqlCommand = connection.CreateCommand();
                sqlCommand.CommandText = "DELETE FROM Products WHERE ProductID = @ProductID;";
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@ProductID", productID);

                result = sqlCommand.ExecuteNonQuery() > 0;
                connection.Close();
            }

            return result;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="attributeID"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool DeleteAttribute(long attributeID)
        {
            bool result;

            // Delete attribute from database
            using (var connection = OpenConnection())
            {
                var sqlCommand = connection.CreateCommand();
                sqlCommand.CommandText = "DELETE FROM ProductAttributes WHERE AttributeID = @AttributeID;";
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@AttributeID", attributeID);

                result = sqlCommand.ExecuteNonQuery() > 0;
                connection.Close();
            }

            return result;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="photoID"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool DeletePhoto(long photoID)
        {
            bool result;

            // Delete photo from database
            using (var connection = OpenConnection())
            {
                var sqlCommand = connection.CreateCommand();
                sqlCommand.CommandText = "DELETE FROM ProductPhotos WHERE PhotoID = @PhotoID;";
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@PhotoID", photoID);

                result = sqlCommand.ExecuteNonQuery() > 0;
                connection.Close();
            }

            return result;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="productID"></param>
        /// <returns></returns>
        public Product Get(int productID)
        {
            Product product = null;

            // Read product from database
            using (var connection = OpenConnection())
            {
                var sqlCommand = connection.CreateCommand();
                sqlCommand.CommandText =
                    @"SELECT * FROM Products WHERE ProductID = @ProductId;";
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@ProductId", productID);

                var reader = sqlCommand.ExecuteReader();
                if (reader.Read())
                    product = new Product
                    {
                        Photo = Convert.ToString(reader["Photo"]),
                        Price = Convert.ToDecimal(reader["Price"]),
                        Unit = Convert.ToString(reader["Unit"]),
                        ProductName = Convert.ToString(reader["ProductName"]),
                        CategoryID = Convert.ToInt32(reader["CategoryID"]),
                        ProductID = Convert.ToInt32(reader["ProductID"]),
                        SupplierID = Convert.ToInt32(reader["SupplierID"])
                    };

                reader.Close();
                connection.Close();
            }

            return product;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="attributeID"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public ProductAttribute GetAttribute(long attributeID)
        {
            ProductAttribute attribute = null;

            // Read attribute from database by attribute ID
            using (var connection = OpenConnection())
            {
                var sqlCommand = connection.CreateCommand();
                sqlCommand.CommandText = "SELECT * FROM ProductAttributes WHERE AttributeID = @AttributeID;";
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@AttributeID", attributeID);

                var reader = sqlCommand.ExecuteReader();
                if (reader.Read())
                    attribute = new ProductAttribute
                    {
                        AttributeID = Convert.ToInt32(reader["AttributeID"]),
                        ProductID = Convert.ToInt32(reader["ProductID"]),
                        AttributeName = Convert.ToString(reader["AttributeName"]),
                        AttributeValue = Convert.ToString(reader["AttributeValue"]),
                        DisplayOrder = Convert.ToInt32(reader["DisplayOrder"])
                    };

                reader.Close();
                connection.Close();
            }

            return attribute;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="photoID"></param>
        /// <returns></returns>
        public ProductPhoto GetPhoto(long photoID)
        {
            ProductPhoto photo = null;

            // Read photo from database by photo ID
            using (var connection = OpenConnection())
            {
                var sqlCommand = connection.CreateCommand();
                sqlCommand.CommandText = "SELECT * FROM ProductPhotos WHERE PhotoID = @PhotoID;";
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@PhotoID", photoID);

                var reader = sqlCommand.ExecuteReader();
                if (reader.Read())
                    photo = new ProductPhoto
                    {
                        Photo = Convert.ToString(reader["Photo"]),
                        ProductID = Convert.ToInt32(reader["ProductID"]),
                        PhotoID = Convert.ToInt32(reader["PhotoID"]),
                        Description = Convert.ToString(reader["Description"]),
                        DisplayOrder = Convert.ToInt32(reader["DisplayOrder"]),
                        IsHidden = Convert.ToBoolean(reader["IsHidden"])
                    };

                reader.Close();
                connection.Close();
            }

            return photo;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="productID"></param>
        /// <returns></returns>
        public bool InUsed(int productID)
        {
            bool result;

            // Check product in used
            using (var connection = OpenConnection())
            {
                var sqlCommand = connection.CreateCommand();
                sqlCommand.CommandText = "SELECT COUNT(*) FROM OrderDetails WHERE ProductID = @ProductID;";
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@ProductID", productID);

                result = Convert.ToInt32(sqlCommand.ExecuteScalar()) > 0;
                connection.Close();
            }

            return result;

        }
        /// <summary>
        /// Lấy danh sách mặt hàng
        /// </summary>
        /// <param name="page"> Page number (Default: 1) </param>
        /// <param name="pageSize"> Page size (Default: 0) </param>
        /// <param name="searchValue"> Search value (Default: "") </param>
        /// <param name="categoryId"> Category ID (Default: 0) </param>
        /// <param name="supplierId"> Supplier ID (Default: 0) </param>
        /// <returns> List of products </returns>
        public IList<Product> List(int page = 1, int pageSize = 0, string searchValue = "", int categoryId = 0, int supplierId = 0)
        {
            var listOfProducts = new List<Product>();

            // Read products from database and add to list
            using (var connection = OpenConnection())
            {
                var sqlCommand = connection.CreateCommand();
                sqlCommand.CommandText =
                    @"SELECT * FROM (SELECT *, ROW_NUMBER() OVER (ORDER BY ProductName) AS RowNumber FROM Products WHERE ((@SearchValue = N'') OR (ProductName LIKE @SearchValue)) AND ((CategoryID = @CategoryId) OR (@CategoryId = 0)) AND ((SupplierID = @SupplierId) OR (@SupplierId = 0))) AS t WHERE (@PageSize = 0) OR (t.RowNumber BETWEEN (@Page - 1) * @PageSize + 1 AND @Page * @PageSize);";
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@Page", page);
                sqlCommand.Parameters.AddWithValue("@PageSize", pageSize);
                sqlCommand.Parameters.AddWithValue("@SearchValue", "%" + searchValue + "%");
                sqlCommand.Parameters.AddWithValue("@CategoryId", categoryId);
                sqlCommand.Parameters.AddWithValue("@SupplierId", supplierId);

                var reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    var product = new Product
                    {
                        Photo = Convert.ToString(reader["Photo"]),
                        Price = Convert.ToDecimal(reader["Price"]),
                        Unit = Convert.ToString(reader["Unit"]),
                        ProductName = Convert.ToString(reader["ProductName"]),
                        CategoryID = Convert.ToInt32(reader["CategoryID"]),
                        ProductID = Convert.ToInt32(reader["ProductID"]),
                        SupplierID = Convert.ToInt32(reader["SupplierID"])
                    };
                    listOfProducts.Add(product);
                }

                reader.Close();
                connection.Close();
            }

            return listOfProducts;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="productID"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IList<ProductAttribute> ListAttributes(int productID)
        {
            var listOfAttributes = new List<ProductAttribute>();

            // Read attributes from database by product ID
            using (var connection = OpenConnection())
            {
                var sqlCommand = connection.CreateCommand();
                sqlCommand.CommandText = "SELECT * FROM ProductAttributes WHERE ProductID = @ProductID;";
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@ProductID", productID);

                var reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                    listOfAttributes.Add(new ProductAttribute
                    {
                        AttributeID = Convert.ToInt32(reader["AttributeID"]),
                        ProductID = Convert.ToInt32(reader["ProductID"]),
                        AttributeName = Convert.ToString(reader["AttributeName"]),
                        AttributeValue = Convert.ToString(reader["AttributeValue"]),
                        DisplayOrder = Convert.ToInt32(reader["DisplayOrder"])
                    });

                reader.Close();
                connection.Close();
            }

            return listOfAttributes;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="productID"></param>
        /// <returns></returns>
        public IList<ProductPhoto> ListPhotos(int productID)
        {
            var listOfPhotos = new List<ProductPhoto>();

            // Read photos from database by product ID
            using (var connection = OpenConnection())
            {
                var sqlCommand = connection.CreateCommand();
                sqlCommand.CommandText = "SELECT * FROM ProductPhotos WHERE ProductID = @ProductID;";
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@ProductID", productID);

                var reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                    listOfPhotos.Add(new ProductPhoto
                    {
                        Photo = Convert.ToString(reader["Photo"]),
                        ProductID = Convert.ToInt32(reader["ProductID"]),
                        PhotoID = Convert.ToInt32(reader["PhotoID"]),
                        Description = Convert.ToString(reader["Description"]),
                        DisplayOrder = Convert.ToInt32(reader["DisplayOrder"]),
                        IsHidden = Convert.ToBoolean(reader["IsHidden"])
                    });

                reader.Close();
                connection.Close();
            }

            return listOfPhotos;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool Update(Product data)
        {
            bool result;

            // Update product to database
            using (var connection = OpenConnection())
            {
                var sqlCommand = connection.CreateCommand();
                sqlCommand.CommandText = "UPDATE Products SET ProductName = @ProductName, SupplierID = @SupplierID, CategoryID = @CategoryID, Unit = @Unit, Price = @Price, Photo = @Photo WHERE ProductID = @ProductID;";
                sqlCommand.CommandType = CommandType.Text;

                sqlCommand.Parameters.AddWithValue("@ProductName", data.ProductName);
                sqlCommand.Parameters.AddWithValue("@SupplierID", data.SupplierID);
                sqlCommand.Parameters.AddWithValue("@CategoryID", data.CategoryID);
                sqlCommand.Parameters.AddWithValue("@Unit", data.Unit);
                sqlCommand.Parameters.AddWithValue("@Price", data.Price);
                sqlCommand.Parameters.AddWithValue("@Photo", data.Photo);
                sqlCommand.Parameters.AddWithValue("@ProductID", data.ProductID);

                result = sqlCommand.ExecuteNonQuery() > 0;
                connection.Close();
            }

            return result;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool UpdateAttribute(ProductAttribute data)
        {
            bool result;

            // Update attribute in database
            using (var connection = OpenConnection())
            {
                var sqlCommand = connection.CreateCommand();
                sqlCommand.CommandText = "UPDATE ProductAttributes SET ProductID = @ProductID, AttributeName = @AttributeName, AttributeValue = @AttributeValue, DisplayOrder = @DisplayOrder WHERE AttributeID = @AttributeID;";
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@ProductID", data.ProductID);
                sqlCommand.Parameters.AddWithValue("@AttributeName", data.AttributeName);
                sqlCommand.Parameters.AddWithValue("@AttributeValue", data.AttributeValue);
                sqlCommand.Parameters.AddWithValue("@DisplayOrder", data.DisplayOrder);
                sqlCommand.Parameters.AddWithValue("@AttributeID", data.AttributeID);

                result = sqlCommand.ExecuteNonQuery() > 0;
                connection.Close();
            }

            return result;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool UpdatePhoto(ProductPhoto data)
        {
            bool result;

            // Update photo in database
            using (var connection = OpenConnection())
            {
                var sqlCommand = connection.CreateCommand();
                sqlCommand.CommandText = "UPDATE ProductPhotos SET ProductID = @ProductID, Photo = @Photo, Description = @Description, DisplayOrder = @DisplayOrder, IsHidden = @IsHidden WHERE PhotoID = @PhotoID;";
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@ProductID", data.ProductID);
                sqlCommand.Parameters.AddWithValue("@Photo", data.Photo);
                sqlCommand.Parameters.AddWithValue("@Description", data.Description);
                sqlCommand.Parameters.AddWithValue("@DisplayOrder", data.DisplayOrder);
                sqlCommand.Parameters.AddWithValue("@IsHidden", data.IsHidden);
                sqlCommand.Parameters.AddWithValue("@PhotoID", data.PhotoID);

                result = sqlCommand.ExecuteNonQuery() > 0;
                connection.Close();
            }

            return result;

        }
    }
}
