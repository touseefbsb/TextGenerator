import React, { useState } from 'react';
import './App.css';
import TextGenerationForm from './TextGenerationForm';
import TextGenerationForm2 from './TextGenerationForm2';

const App: React.FC = () => {
    const [generatedText, setGeneratedText] = useState('');
    const [generatedText2, setGeneratedText2] = useState('');

    const handleGenerateText = async (template: string, dataModel: any) => {
        try {
            // Send a POST request to the backend API endpoint
            const response = await fetch('https://localhost:7220/TextGenerator/GenerateText', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({ template, dataModel }),
            });

            if (response.ok) {
                // If the response is successful, parse it as JSON
                const result = await response.json();

                // Update the 'generatedText' state with the result
                setGeneratedText(result.result);
            } else {
                // Handle error cases if the API request was not successful
                console.error('API request failed.');
                setGeneratedText('Error: Unable to generate text.');
            }
        } catch (error) {
            // Handle exceptions such as network errors
            console.error('An error occurred:', error);
            setGeneratedText('Error: An error occurred.');
        }
    };

    const handleGenerateText2 = async (template: string, dataModel2: any) => {
        try {
            // Send a POST request to the backend API endpoint for the second data model
            const response = await fetch('https://localhost:7220/TextGenerator/GenerateText2', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({ template, dataModel: dataModel2 }),
            });

            if (response.ok) {
                // If the response is successful, parse it as JSON
                const result = await response.json();

                // Update the 'generatedText2' state with the result
                setGeneratedText2(result.result);
            } else {
                // Handle error cases if the API request was not successful
                console.error('API request for DataModel2 failed.');
                setGeneratedText2('Error: Unable to generate text for DataModel2.');
            }
        } catch (error) {
            // Handle exceptions such as network errors
            console.error('An error occurred for DataModel2:', error);
            setGeneratedText2('Error: An error occurred for DataModel2.');
        }
    };


    return (
        <div className="App">
            <h2>Text Generation App</h2>
            <TextGenerationForm onGenerateText={handleGenerateText} />
            <TextGenerationForm2 onGenerateText={handleGenerateText2} />
            <div >
                <h3>Generated Text:</h3>
                <p>{generatedText}</p>
            </div>
            <div>
                <h3>Generated Text for DataModel2:</h3>
                <p>{generatedText2}</p>
            </div>
        </div>
    );
};

export default App;
