import './App.css';
import ApplicationForm from './components/ApplicationForm';
import ApplicationList from './components/ApplicationList';

function App() {
  return (
    <div className="App">
      <h1>Application Tracker</h1>

      <div className="button-container">
        <ApplicationForm />
        <button>Delete Application</button>
        <button>Update Application</button>
        <ApplicationList />
      </div>
    </div>
  );
}

export default App;