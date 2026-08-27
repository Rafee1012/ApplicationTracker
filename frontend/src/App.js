import './App.css';
import ApplicationForm from './components/ApplicationForm';
import ApplicationList from './components/ApplicationList';
import { Toaster } from "react-hot-toast";

function App() {
  return (
    <div className="App">
      <h1>Application Tracker</h1>

      <div className="button-container">
        <Toaster />
        <ApplicationForm />
        <button>Delete Application</button>
        <button>Update Application</button>
        <ApplicationList />
      </div>
    </div>
  );
}

export default App;