export class ViewManager {
    constructor() {
        this.setupEventListeners();
    }

    setupEventListeners() {
        document.getElementById('individualViewBtn').addEventListener('click', () =>
            this.toggleView('individual'));
        document.getElementById('totalViewBtn').addEventListener('click', () =>
            this.toggleView('total'));
    }

    toggleView(view) {
        const isIndividual = view === 'individual';
        document.getElementById('vehiclePerformanceSection').style.display =
            isIndividual ? 'block' : 'none';
        document.getElementById('totalPerformanceSection').style.display =
            isIndividual ? 'none' : 'block';

        document.getElementById('individualViewBtn').classList.toggle('active', isIndividual);
        document.getElementById('totalViewBtn').classList.toggle('active', !isIndividual);
    }
}