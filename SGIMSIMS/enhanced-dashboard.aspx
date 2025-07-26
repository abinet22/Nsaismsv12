<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="enhanced-dashboard.aspx.cs" Inherits="SGIMSIMS.enhanced_dashboard" %>

<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>Enhanced Dashboard - SGIMIMS</title>
    <meta name="description" content="Advanced Inventory & Sales Management Dashboard">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <link rel="apple-touch-icon" href="apple-icon.png">
    <link rel="shortcut icon" href="favicon.ico">

    <!-- Core CSS -->
    <link rel="stylesheet" href="vendors/bootstrap/dist/css/bootstrap.min.css">
    <link rel="stylesheet" href="vendors/font-awesome/css/font-awesome.min.css">
    <link rel="stylesheet" href="vendors/themify-icons/css/themify-icons.css">
    <link rel="stylesheet" href="vendors/datatables.net-bs4/css/dataTables.bootstrap4.min.css">
    
    <!-- Custom Enhanced CSS -->
    <link rel="stylesheet" href="assets/css/style.css">
    <link rel="stylesheet" href="assets/css/enhanced-ui.css">

    <!-- Google Fonts -->
    <link href="https://fonts.googleapis.com/css2?family=Inter:wght@300;400;500;600;700&display=swap" rel="stylesheet">
</head>

<body>
    <form runat="server">
        <!-- Enhanced Sidebar -->
        <aside id="left-panel" class="left-panel enhanced-sidebar">
            <nav class="navbar navbar-expand-sm navbar-default">
                <div class="navbar-header">
                    <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#main-menu">
                        <i class="fa fa-bars"></i>
                    </button>
                    <a class="navbar-brand" href="#">
                        <img src="images/logo.png" alt="Logo" style="height: 40px;">
                    </a>
                </div>

                <div id="main-menu" class="main-menu collapse navbar-collapse">
                    <ul class="nav navbar-nav">
                        <li class="nav-item">
                            <a class="nav-link active" href="#"><i class="fa fa-dashboard"></i> Dashboard</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="inventorymanagermain.aspx"><i class="fa fa-cube"></i> Inventory</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="salesmanagermain.aspx"><i class="fa fa-shopping-cart"></i> Sales</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="#"><i class="fa fa-users"></i> Customers</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="#"><i class="fa fa-bar-chart"></i> Analytics</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="#"><i class="fa fa-cog"></i> Settings</a>
                        </li>
                    </ul>
                </div>
            </nav>
        </aside>

        <!-- Enhanced Main Panel -->
        <div id="right-panel" class="right-panel">
            <!-- Enhanced Header -->
            <header id="header" class="header enhanced-header">
                <div class="header-menu">
                    <div class="col-sm-7">
                        <a id="menuToggle" class="menutoggle pull-left"><i class="fa fa-tasks"></i></a>
                        <div class="header-left">
                            <!-- Global Search -->
                            <div class="form-inline">
                                <div class="search-element">
                                    <input type="text" id="globalSearch" class="form-control" placeholder="Search anything..." style="border-radius: 25px; width: 300px;">
                                    <i class="fa fa-search"></i>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="col-sm-5">
                        <div class="user-area dropdown float-right">
                            <!-- Dark Mode Toggle -->
                            <button id="darkModeToggle" class="btn btn-outline-secondary mr-2" style="border-radius: 50%; width: 40px; height: 40px;">
                                <i class="fa fa-moon-o"></i>
                            </button>
                            
                            <!-- Notifications -->
                            <div class="dropdown for-notification mr-2">
                                <button class="btn dropdown-toggle enhanced-btn-primary" type="button" id="notification" data-toggle="dropdown">
                                    <i class="fa fa-bell"></i>
                                    <span class="notification-badge">3</span>
                                </button>
                                <div class="dropdown-menu" aria-labelledby="notification">
                                    <p class="red-text">You have 3 Notification</p>
                                    <a class="dropdown-item media bg-flat-color-1" href="#">
                                        <i class="fa fa-check"></i>
                                        <p>Server #1 overloaded.</p>
                                    </a>
                                </div>
                            </div>

                            <!-- User Menu -->
                            <a href="#" class="dropdown-toggle" data-toggle="dropdown">
                                <img class="user-avatar rounded-circle" src="images/admin.jpg" alt="User Avatar" style="width: 40px; height: 40px;">
                            </a>
                            <div class="user-menu dropdown-menu">
                                <a class="nav-link" href="#"><i class="fa fa-user"></i> My Profile</a>
                                <a class="nav-link" href="#"><i class="fa fa-cog"></i> Settings</a>
                                <a class="nav-link" href="#"><i class="fa fa-power-off"></i> Logout</a>
                            </div>
                        </div>
                    </div>
                </div>
            </header>

            <!-- Enhanced Breadcrumbs -->
            <div class="breadcrumbs fade-in">
                <div class="col-sm-4">
                    <div class="page-header float-left">
                        <div class="page-title">
                            <h1 class="text-gradient">Enhanced Dashboard</h1>
                        </div>
                    </div>
                </div>
                <div class="col-sm-8">
                    <div class="page-header float-right">
                        <div class="page-title">
                            <ol class="breadcrumb text-right">
                                <li><a href="#">Dashboard</a></li>
                                <li class="active">Enhanced Overview</li>
                            </ol>
                        </div>
                    </div>
                </div>
            </div>

            <!-- Enhanced Content -->
            <div class="content mt-3">
                <!-- Enhanced Metrics Row -->
                <div class="row mb-4">
                    <div class="col-xl-3 col-lg-6 mb-4">
                        <div class="metric-card metric-success slide-in-left" id="totalSales">
                            <div class="metric-icon">
                                <i class="fa fa-dollar"></i>
                            </div>
                            <div class="metric-number">1,247</div>
                            <div class="metric-label">Total Sales</div>
                        </div>
                    </div>
                    <div class="col-xl-3 col-lg-6 mb-4">
                        <div class="metric-card metric-info slide-in-left" id="totalProducts" style="animation-delay: 0.1s;">
                            <div class="metric-icon">
                                <i class="fa fa-cube"></i>
                            </div>
                            <div class="metric-number">856</div>
                            <div class="metric-label">Products</div>
                        </div>
                    </div>
                    <div class="col-xl-3 col-lg-6 mb-4">
                        <div class="metric-card metric-warning slide-in-left" id="lowStock" style="animation-delay: 0.2s;">
                            <div class="metric-icon">
                                <i class="fa fa-exclamation-triangle"></i>
                            </div>
                            <div class="metric-number">23</div>
                            <div class="metric-label">Low Stock</div>
                        </div>
                    </div>
                    <div class="col-xl-3 col-lg-6 mb-4">
                        <div class="metric-card metric-danger slide-in-left" id="pendingOrders" style="animation-delay: 0.3s;">
                            <div class="metric-icon">
                                <i class="fa fa-clock-o"></i>
                            </div>
                            <div class="metric-number">12</div>
                            <div class="metric-label">Pending Orders</div>
                        </div>
                    </div>
                </div>

                <!-- Charts Row -->
                <div class="row mb-4">
                    <!-- Sales Chart -->
                    <div class="col-lg-8 mb-4">
                        <div class="chart-container fade-in">
                            <h3 class="chart-title">Sales Analytics</h3>
                            <canvas id="salesChart" height="300"></canvas>
                        </div>
                    </div>
                    
                    <!-- Inventory Chart -->
                    <div class="col-lg-4 mb-4">
                        <div class="chart-container fade-in">
                            <h3 class="chart-title">Inventory Status</h3>
                            <canvas id="inventoryChart" height="300"></canvas>
                        </div>
                    </div>
                </div>

                <!-- Secondary Charts Row -->
                <div class="row mb-4">
                    <!-- Revenue Chart -->
                    <div class="col-lg-6 mb-4">
                        <div class="chart-container fade-in">
                            <h3 class="chart-title">Quarterly Revenue</h3>
                            <canvas id="revenueChart" height="250"></canvas>
                        </div>
                    </div>
                    
                    <!-- Performance Chart -->
                    <div class="col-lg-6 mb-4">
                        <div class="chart-container fade-in">
                            <h3 class="chart-title">Performance Metrics</h3>
                            <canvas id="performanceChart" height="250"></canvas>
                        </div>
                    </div>
                </div>

                <!-- Enhanced Data Table -->
                <div class="row mb-4">
                    <div class="col-12">
                        <div class="enhanced-card fade-in">
                            <div class="card-header">
                                <strong class="card-title">Recent Transactions</strong>
                                <div class="float-right">
                                    <button class="enhanced-btn enhanced-btn-primary btn-sm">
                                        <i class="fa fa-plus"></i> Add New
                                    </button>
                                </div>
                            </div>
                            <div class="card-body">
                                <div class="enhanced-table">
                                    <table class="table table-striped">
                                        <thead>
                                            <tr>
                                                <th>ID</th>
                                                <th>Product</th>
                                                <th>Customer</th>
                                                <th>Amount</th>
                                                <th>Date</th>
                                                <th>Status</th>
                                                <th>Actions</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <td>#001</td>
                                                <td>Product A</td>
                                                <td>John Doe</td>
                                                <td>$1,250.00</td>
                                                <td>2024-01-15</td>
                                                <td><span class="badge badge-success">Completed</span></td>
                                                <td>
                                                    <button class="btn btn-sm btn-primary" data-toggle="tooltip" title="View">
                                                        <i class="fa fa-eye"></i>
                                                    </button>
                                                    <button class="btn btn-sm btn-warning" data-toggle="tooltip" title="Edit">
                                                        <i class="fa fa-edit"></i>
                                                    </button>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>#002</td>
                                                <td>Product B</td>
                                                <td>Jane Smith</td>
                                                <td>$890.00</td>
                                                <td>2024-01-14</td>
                                                <td><span class="badge badge-warning">Pending</span></td>
                                                <td>
                                                    <button class="btn btn-sm btn-primary" data-toggle="tooltip" title="View">
                                                        <i class="fa fa-eye"></i>
                                                    </button>
                                                    <button class="btn btn-sm btn-warning" data-toggle="tooltip" title="Edit">
                                                        <i class="fa fa-edit"></i>
                                                    </button>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>#003</td>
                                                <td>Product C</td>
                                                <td>Mike Johnson</td>
                                                <td>$450.00</td>
                                                <td>2024-01-13</td>
                                                <td><span class="badge badge-danger">Cancelled</span></td>
                                                <td>
                                                    <button class="btn btn-sm btn-primary" data-toggle="tooltip" title="View">
                                                        <i class="fa fa-eye"></i>
                                                    </button>
                                                    <button class="btn btn-sm btn-warning" data-toggle="tooltip" title="Edit">
                                                        <i class="fa fa-edit"></i>
                                                    </button>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <!-- Progress Indicators -->
                <div class="row mb-4">
                    <div class="col-md-6">
                        <div class="enhanced-card fade-in">
                            <div class="card-header">
                                <strong>Monthly Targets</strong>
                            </div>
                            <div class="card-body">
                                <div class="mb-3">
                                    <div class="d-flex justify-content-between">
                                        <span>Sales Target</span>
                                        <span>75%</span>
                                    </div>
                                    <div class="enhanced-progress">
                                        <div class="enhanced-progress-bar" data-width="75"></div>
                                    </div>
                                </div>
                                <div class="mb-3">
                                    <div class="d-flex justify-content-between">
                                        <span>Inventory Turnover</span>
                                        <span>60%</span>
                                    </div>
                                    <div class="enhanced-progress">
                                        <div class="enhanced-progress-bar" data-width="60"></div>
                                    </div>
                                </div>
                                <div class="mb-3">
                                    <div class="d-flex justify-content-between">
                                        <span>Customer Satisfaction</span>
                                        <span>90%</span>
                                    </div>
                                    <div class="enhanced-progress">
                                        <div class="enhanced-progress-bar" data-width="90"></div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="enhanced-card fade-in">
                            <div class="card-header">
                                <strong>Quick Actions</strong>
                            </div>
                            <div class="card-body">
                                <div class="row">
                                    <div class="col-6 mb-3">
                                        <button class="enhanced-btn enhanced-btn-primary btn-block">
                                            <i class="fa fa-plus"></i> New Order
                                        </button>
                                    </div>
                                    <div class="col-6 mb-3">
                                        <button class="enhanced-btn enhanced-btn-success btn-block">
                                            <i class="fa fa-cube"></i> Add Product
                                        </button>
                                    </div>
                                    <div class="col-6 mb-3">
                                        <button class="enhanced-btn enhanced-btn-info btn-block">
                                            <i class="fa fa-user"></i> New Customer
                                        </button>
                                    </div>
                                    <div class="col-6 mb-3">
                                        <button class="enhanced-btn enhanced-btn-warning btn-block">
                                            <i class="fa fa-file-text"></i> Generate Report
                                        </button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <!-- Enhanced Modal Example -->
        <div class="modal fade enhanced-modal" id="exampleModal" tabindex="-1" role="dialog">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">Enhanced Modal</h5>
                        <button type="button" class="close" data-dismiss="modal">
                            <span>&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <div class="enhanced-form-group">
                            <input type="text" class="enhanced-form-control" placeholder=" " required>
                            <label class="floating-label">Product Name</label>
                        </div>
                        <div class="enhanced-form-group">
                            <input type="number" class="enhanced-form-control" placeholder=" " required>
                            <label class="floating-label">Price</label>
                        </div>
                        <div class="enhanced-form-group">
                            <textarea class="enhanced-form-control" placeholder=" " rows="3"></textarea>
                            <label class="floating-label">Description</label>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="enhanced-btn enhanced-btn-primary">Save</button>
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancel</button>
                    </div>
                </div>
            </div>
        </div>
    </form>

    <!-- Core JavaScript -->
    <script src="vendors/jquery/dist/jquery.min.js"></script>
    <script src="vendors/popper.js/dist/umd/popper.min.js"></script>
    <script src="vendors/bootstrap/dist/js/bootstrap.min.js"></script>
    <script src="vendors/datatables.net/js/jquery.dataTables.min.js"></script>
    <script src="vendors/datatables.net-bs4/js/dataTables.bootstrap4.min.js"></script>
    
    <!-- Chart.js -->
    <script src="vendors/chart.js/dist/Chart.bundle.min.js"></script>
    
    <!-- Enhanced UI JavaScript -->
    <script src="assets/js/main.js"></script>
    <script src="assets/js/enhanced-ui.js"></script>
</body>
</html>