/**
 * Enhanced UI JavaScript for Inventory & Sales Management System
 * Features: Interactive dashboards, real-time charts, advanced animations
 */

class EnhancedUI {
    constructor() {
        this.charts = {};
        this.notifications = [];
        this.darkMode = localStorage.getItem('darkMode') === 'true';
        this.init();
    }

    init() {
        this.initializeComponents();
        this.setupEventListeners();
        this.initializeCharts();
        this.setupDarkMode();
        this.setupRealTimeUpdates();
        this.initializeAnimations();
    }

    // =============================================
    // COMPONENT INITIALIZATION
    // =============================================

    initializeComponents() {
        // Initialize tooltips
        if (typeof $ !== 'undefined') {
            $('[data-toggle="tooltip"]').tooltip();
        }

        // Initialize popovers
        if (typeof $ !== 'undefined') {
            $('[data-toggle="popover"]').popover();
        }

        // Initialize enhanced form controls
        this.initializeFormControls();

        // Initialize data tables
        this.initializeDataTables();

        // Initialize progress bars
        this.initializeProgressBars();
    }

    initializeFormControls() {
        // Enhanced form validation
        const forms = document.querySelectorAll('.enhanced-form');
        forms.forEach(form => {
            this.setupFormValidation(form);
        });

        // Floating labels
        const inputs = document.querySelectorAll('.enhanced-form-control');
        inputs.forEach(input => {
            this.setupFloatingLabel(input);
        });
    }

    setupFormValidation(form) {
        form.addEventListener('submit', (e) => {
            if (!this.validateForm(form)) {
                e.preventDefault();
                e.stopPropagation();
            }
            form.classList.add('was-validated');
        });
    }

    validateForm(form) {
        const inputs = form.querySelectorAll('.enhanced-form-control[required]');
        let isValid = true;

        inputs.forEach(input => {
            if (!input.value.trim()) {
                this.showFieldError(input, 'This field is required');
                isValid = false;
            } else {
                this.clearFieldError(input);
            }
        });

        return isValid;
    }

    showFieldError(input, message) {
        const errorElement = input.parentNode.querySelector('.field-error') || 
                           document.createElement('div');
        errorElement.className = 'field-error text-danger small mt-1';
        errorElement.textContent = message;
        if (!input.parentNode.querySelector('.field-error')) {
            input.parentNode.appendChild(errorElement);
        }
        input.classList.add('is-invalid');
    }

    clearFieldError(input) {
        const errorElement = input.parentNode.querySelector('.field-error');
        if (errorElement) {
            errorElement.remove();
        }
        input.classList.remove('is-invalid');
        input.classList.add('is-valid');
    }

    setupFloatingLabel(input) {
        const label = input.nextElementSibling;
        if (label && label.classList.contains('floating-label')) {
            input.addEventListener('focus', () => {
                label.classList.add('active');
            });

            input.addEventListener('blur', () => {
                if (!input.value) {
                    label.classList.remove('active');
                }
            });

            // Check initial state
            if (input.value) {
                label.classList.add('active');
            }
        }
    }

    // =============================================
    // DATA TABLE ENHANCEMENTS
    // =============================================

    initializeDataTables() {
        if (typeof $ !== 'undefined' && $.fn.DataTable) {
            $('.enhanced-table table').each(function() {
                if (!$(this).hasClass('dataTable')) {
                    $(this).DataTable({
                        responsive: true,
                        pageLength: 10,
                        lengthMenu: [[10, 25, 50, -1], [10, 25, 50, "All"]],
                        dom: '<"row"<"col-sm-12 col-md-6"l><"col-sm-12 col-md-6"f>>' +
                             '<"row"<"col-sm-12"tr>>' +
                             '<"row"<"col-sm-12 col-md-5"i><"col-sm-12 col-md-7"p>>',
                        language: {
                            search: "Search records:",
                            lengthMenu: "Show _MENU_ entries",
                            info: "Showing _START_ to _END_ of _TOTAL_ entries",
                            paginate: {
                                first: "First",
                                last: "Last",
                                next: "Next",
                                previous: "Previous"
                            }
                        },
                        drawCallback: function() {
                            // Re-initialize tooltips after table redraw
                            $('[data-toggle="tooltip"]').tooltip();
                        }
                    });
                }
            });
        }
    }

    // =============================================
    // CHART INITIALIZATION
    // =============================================

    initializeCharts() {
        this.createSalesChart();
        this.createInventoryChart();
        this.createRevenueChart();
        this.createPerformanceChart();
    }

    createSalesChart() {
        const ctx = document.getElementById('salesChart');
        if (ctx && typeof Chart !== 'undefined') {
            this.charts.sales = new Chart(ctx, {
                type: 'line',
                data: {
                    labels: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun'],
                    datasets: [{
                        label: 'Sales',
                        data: [12, 19, 3, 5, 2, 3],
                        borderColor: 'rgb(102, 126, 234)',
                        backgroundColor: 'rgba(102, 126, 234, 0.1)',
                        borderWidth: 3,
                        fill: true,
                        tension: 0.4
                    }]
                },
                options: {
                    responsive: true,
                    maintainAspectRatio: false,
                    plugins: {
                        legend: {
                            display: true,
                            position: 'top'
                        }
                    },
                    scales: {
                        y: {
                            beginAtZero: true,
                            grid: {
                                color: 'rgba(0, 0, 0, 0.1)'
                            }
                        },
                        x: {
                            grid: {
                                color: 'rgba(0, 0, 0, 0.1)'
                            }
                        }
                    },
                    animation: {
                        duration: 2000,
                        easing: 'easeInOutQuart'
                    }
                }
            });
        }
    }

    createInventoryChart() {
        const ctx = document.getElementById('inventoryChart');
        if (ctx && typeof Chart !== 'undefined') {
            this.charts.inventory = new Chart(ctx, {
                type: 'doughnut',
                data: {
                    labels: ['In Stock', 'Low Stock', 'Out of Stock'],
                    datasets: [{
                        data: [65, 25, 10],
                        backgroundColor: [
                            'rgba(17, 153, 142, 0.8)',
                            'rgba(240, 147, 251, 0.8)',
                            'rgba(250, 112, 154, 0.8)'
                        ],
                        borderWidth: 0
                    }]
                },
                options: {
                    responsive: true,
                    maintainAspectRatio: false,
                    plugins: {
                        legend: {
                            position: 'bottom'
                        }
                    },
                    animation: {
                        duration: 2000,
                        easing: 'easeInOutQuart'
                    }
                }
            });
        }
    }

    createRevenueChart() {
        const ctx = document.getElementById('revenueChart');
        if (ctx && typeof Chart !== 'undefined') {
            this.charts.revenue = new Chart(ctx, {
                type: 'bar',
                data: {
                    labels: ['Q1', 'Q2', 'Q3', 'Q4'],
                    datasets: [{
                        label: 'Revenue',
                        data: [15000, 25000, 18000, 30000],
                        backgroundColor: [
                            'rgba(102, 126, 234, 0.8)',
                            'rgba(79, 172, 254, 0.8)',
                            'rgba(17, 153, 142, 0.8)',
                            'rgba(240, 147, 251, 0.8)'
                        ],
                        borderRadius: 10,
                        borderSkipped: false
                    }]
                },
                options: {
                    responsive: true,
                    maintainAspectRatio: false,
                    plugins: {
                        legend: {
                            display: false
                        }
                    },
                    scales: {
                        y: {
                            beginAtZero: true,
                            grid: {
                                color: 'rgba(0, 0, 0, 0.1)'
                            }
                        },
                        x: {
                            grid: {
                                display: false
                            }
                        }
                    },
                    animation: {
                        duration: 2000,
                        easing: 'easeInOutQuart'
                    }
                }
            });
        }
    }

    createPerformanceChart() {
        const ctx = document.getElementById('performanceChart');
        if (ctx && typeof Chart !== 'undefined') {
            this.charts.performance = new Chart(ctx, {
                type: 'radar',
                data: {
                    labels: ['Sales', 'Inventory', 'Customer Service', 'Efficiency', 'Growth'],
                    datasets: [{
                        label: 'Performance',
                        data: [80, 90, 75, 85, 70],
                        borderColor: 'rgb(102, 126, 234)',
                        backgroundColor: 'rgba(102, 126, 234, 0.2)',
                        borderWidth: 2
                    }]
                },
                options: {
                    responsive: true,
                    maintainAspectRatio: false,
                    scales: {
                        r: {
                            beginAtZero: true,
                            max: 100
                        }
                    },
                    animation: {
                        duration: 2000,
                        easing: 'easeInOutQuart'
                    }
                }
            });
        }
    }

    // =============================================
    // PROGRESS BARS
    // =============================================

    initializeProgressBars() {
        const progressBars = document.querySelectorAll('.enhanced-progress-bar');
        progressBars.forEach(bar => {
            const width = bar.dataset.width || '0';
            bar.style.setProperty('--progress-width', width + '%');
            
            // Animate on scroll
            this.observeElement(bar, () => {
                bar.style.width = width + '%';
            });
        });
    }

    // =============================================
    // DARK MODE
    // =============================================

    setupDarkMode() {
        const toggle = document.getElementById('darkModeToggle');
        if (toggle) {
            toggle.addEventListener('click', () => {
                this.toggleDarkMode();
            });
        }

        // Apply initial state
        if (this.darkMode) {
            document.body.classList.add('dark-mode');
        }
    }

    toggleDarkMode() {
        this.darkMode = !this.darkMode;
        localStorage.setItem('darkMode', this.darkMode);
        
        document.body.classList.toggle('dark-mode', this.darkMode);
        
        // Update charts for dark mode
        this.updateChartsForTheme();
        
        this.showNotification(
            this.darkMode ? 'Dark mode enabled' : 'Light mode enabled',
            'info'
        );
    }

    updateChartsForTheme() {
        Object.values(this.charts).forEach(chart => {
            if (chart && chart.options) {
                const textColor = this.darkMode ? '#ffffff' : '#000000';
                const gridColor = this.darkMode ? 'rgba(255, 255, 255, 0.1)' : 'rgba(0, 0, 0, 0.1)';
                
                if (chart.options.scales) {
                    Object.values(chart.options.scales).forEach(scale => {
                        if (scale.ticks) scale.ticks.color = textColor;
                        if (scale.grid) scale.grid.color = gridColor;
                    });
                }
                
                chart.update();
            }
        });
    }

    // =============================================
    // REAL-TIME UPDATES
    // =============================================

    setupRealTimeUpdates() {
        // Simulate real-time updates
        setInterval(() => {
            this.updateMetrics();
            this.updateNotifications();
        }, 30000); // Update every 30 seconds

        // Update charts every 5 minutes
        setInterval(() => {
            this.updateChartData();
        }, 300000);
    }

    updateMetrics() {
        const metrics = document.querySelectorAll('.metric-number');
        metrics.forEach(metric => {
            const currentValue = parseInt(metric.textContent);
            const change = Math.floor(Math.random() * 10) - 5; // Random change -5 to +5
            const newValue = Math.max(0, currentValue + change);
            
            this.animateCounter(metric, currentValue, newValue);
        });
    }

    animateCounter(element, start, end) {
        const duration = 1000;
        const range = end - start;
        const increment = range / (duration / 16);
        let current = start;
        
        const timer = setInterval(() => {
            current += increment;
            if ((increment > 0 && current >= end) || (increment < 0 && current <= end)) {
                current = end;
                clearInterval(timer);
            }
            element.textContent = Math.floor(current);
        }, 16);
    }

    updateChartData() {
        // Update sales chart with new data
        if (this.charts.sales) {
            const newData = this.charts.sales.data.datasets[0].data.map(() => 
                Math.floor(Math.random() * 30) + 1
            );
            this.charts.sales.data.datasets[0].data = newData;
            this.charts.sales.update('active');
        }

        // Update inventory chart
        if (this.charts.inventory) {
            const total = 100;
            const inStock = Math.floor(Math.random() * 40) + 50;
            const lowStock = Math.floor(Math.random() * 20) + 10;
            const outOfStock = total - inStock - lowStock;
            
            this.charts.inventory.data.datasets[0].data = [inStock, lowStock, outOfStock];
            this.charts.inventory.update('active');
        }
    }

    // =============================================
    // NOTIFICATIONS
    // =============================================

    showNotification(message, type = 'info', duration = 5000) {
        const notification = document.createElement('div');
        notification.className = `enhanced-alert enhanced-alert-${type} notification fade-in`;
        notification.innerHTML = `
            <strong>${type.charAt(0).toUpperCase() + type.slice(1)}</strong>
            ${message}
            <button type="button" class="close" onclick="this.parentElement.remove()">
                <span>&times;</span>
            </button>
        `;

        const container = document.getElementById('notificationContainer') || 
                          this.createNotificationContainer();
        container.appendChild(notification);

        // Auto-remove after duration
        setTimeout(() => {
            if (notification.parentElement) {
                notification.classList.add('fade-out');
                setTimeout(() => notification.remove(), 300);
            }
        }, duration);
    }

    createNotificationContainer() {
        const container = document.createElement('div');
        container.id = 'notificationContainer';
        container.style.cssText = `
            position: fixed;
            top: 20px;
            right: 20px;
            z-index: 9999;
            max-width: 400px;
        `;
        document.body.appendChild(container);
        return container;
    }

    updateNotifications() {
        // Simulate new notifications
        const notifications = [
            { message: 'New order received', type: 'success' },
            { message: 'Low stock alert', type: 'warning' },
            { message: 'System backup completed', type: 'info' },
            { message: 'Payment overdue', type: 'danger' }
        ];

        if (Math.random() > 0.8) { // 20% chance
            const randomNotification = notifications[Math.floor(Math.random() * notifications.length)];
            this.showNotification(randomNotification.message, randomNotification.type);
        }
    }

    // =============================================
    // ANIMATIONS
    // =============================================

    initializeAnimations() {
        this.setupScrollAnimations();
        this.setupHoverEffects();
        this.setupLoadingAnimations();
    }

    setupScrollAnimations() {
        const animatedElements = document.querySelectorAll('.fade-in, .slide-in-left, .slide-in-right');
        
        animatedElements.forEach(element => {
            this.observeElement(element, () => {
                element.style.opacity = '1';
                element.style.transform = 'translateY(0) translateX(0)';
            });
        });
    }

    observeElement(element, callback) {
        const observer = new IntersectionObserver((entries) => {
            entries.forEach(entry => {
                if (entry.isIntersecting) {
                    callback();
                    observer.unobserve(element);
                }
            });
        }, { threshold: 0.1 });

        observer.observe(element);
    }

    setupHoverEffects() {
        // Enhanced card hover effects
        const cards = document.querySelectorAll('.enhanced-card, .metric-card');
        cards.forEach(card => {
            card.addEventListener('mouseenter', () => {
                card.style.transform = 'translateY(-5px) scale(1.02)';
            });

            card.addEventListener('mouseleave', () => {
                card.style.transform = 'translateY(0) scale(1)';
            });
        });
    }

    setupLoadingAnimations() {
        // Add loading states to buttons
        const buttons = document.querySelectorAll('.enhanced-btn');
        buttons.forEach(button => {
            button.addEventListener('click', () => {
                if (!button.disabled) {
                    const originalText = button.innerHTML;
                    button.innerHTML = '<span class="loading-spinner"></span> Loading...';
                    button.disabled = true;

                    // Simulate async operation
                    setTimeout(() => {
                        button.innerHTML = originalText;
                        button.disabled = false;
                    }, 2000);
                }
            });
        });
    }

    // =============================================
    // EVENT LISTENERS
    // =============================================

    setupEventListeners() {
        // Sidebar toggle
        const sidebarToggle = document.getElementById('menuToggle');
        if (sidebarToggle) {
            sidebarToggle.addEventListener('click', () => {
                this.toggleSidebar();
            });
        }

        // Search functionality
        const searchInput = document.getElementById('globalSearch');
        if (searchInput) {
            searchInput.addEventListener('input', (e) => {
                this.performGlobalSearch(e.target.value);
            });
        }

        // Keyboard shortcuts
        document.addEventListener('keydown', (e) => {
            this.handleKeyboardShortcuts(e);
        });

        // Window resize
        window.addEventListener('resize', () => {
            this.handleResize();
        });
    }

    toggleSidebar() {
        const sidebar = document.getElementById('left-panel');
        if (sidebar) {
            sidebar.classList.toggle('show');
        }
    }

    performGlobalSearch(query) {
        // Implement global search functionality
        console.log('Searching for:', query);
        // This would typically make an AJAX call to search endpoint
    }

    handleKeyboardShortcuts(e) {
        // Ctrl/Cmd + K for search
        if ((e.ctrlKey || e.metaKey) && e.key === 'k') {
            e.preventDefault();
            const searchInput = document.getElementById('globalSearch');
            if (searchInput) {
                searchInput.focus();
            }
        }

        // Escape to close modals
        if (e.key === 'Escape') {
            const activeModal = document.querySelector('.modal.show');
            if (activeModal && typeof $ !== 'undefined') {
                $(activeModal).modal('hide');
            }
        }
    }

    handleResize() {
        // Resize charts
        Object.values(this.charts).forEach(chart => {
            if (chart && chart.resize) {
                chart.resize();
            }
        });
    }

    // =============================================
    // UTILITY METHODS
    // =============================================

    formatNumber(num) {
        return new Intl.NumberFormat().format(num);
    }

    formatCurrency(amount, currency = 'USD') {
        return new Intl.NumberFormat('en-US', {
            style: 'currency',
            currency: currency
        }).format(amount);
    }

    formatDate(date) {
        return new Intl.DateTimeFormat('en-US', {
            year: 'numeric',
            month: 'short',
            day: 'numeric'
        }).format(new Date(date));
    }

    debounce(func, wait) {
        let timeout;
        return function executedFunction(...args) {
            const later = () => {
                clearTimeout(timeout);
                func(...args);
            };
            clearTimeout(timeout);
            timeout = setTimeout(later, wait);
        };
    }

    // =============================================
    // PUBLIC API
    // =============================================

    refreshCharts() {
        Object.values(this.charts).forEach(chart => {
            if (chart && chart.update) {
                chart.update();
            }
        });
    }

    updateMetricCard(id, value, label) {
        const card = document.getElementById(id);
        if (card) {
            const numberElement = card.querySelector('.metric-number');
            const labelElement = card.querySelector('.metric-label');
            
            if (numberElement) {
                const currentValue = parseInt(numberElement.textContent) || 0;
                this.animateCounter(numberElement, currentValue, value);
            }
            
            if (labelElement && label) {
                labelElement.textContent = label;
            }
        }
    }

    showModal(id, options = {}) {
        const modal = document.getElementById(id);
        if (modal && typeof $ !== 'undefined') {
            $(modal).modal('show');
        }
    }

    hideModal(id) {
        const modal = document.getElementById(id);
        if (modal && typeof $ !== 'undefined') {
            $(modal).modal('hide');
        }
    }
}

// Initialize Enhanced UI when DOM is ready
document.addEventListener('DOMContentLoaded', () => {
    window.enhancedUI = new EnhancedUI();
});

// Export for module systems
if (typeof module !== 'undefined' && module.exports) {
    module.exports = EnhancedUI;
}