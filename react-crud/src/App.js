import './App.css';
import {store} from './actions/store';
import {Provider} from 'react-redux';

function App() {
  return (
    <Provider store={store}>
      <DCandidates />
    </Provider>
  );
}

export default App;
