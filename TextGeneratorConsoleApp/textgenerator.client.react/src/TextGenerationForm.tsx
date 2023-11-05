import React, { useState } from 'react';

interface TextGenerationFormProps {
    onGenerateText: (template: string, dataModel: any) => void;
}

const TextGenerationForm: React.FC<TextGenerationFormProps> = ({ onGenerateText }) => {
    const [template, setTemplate] = useState('');
    const [name, setName] = useState('');
    const [city, setCity] = useState('');
    const [line1, setLine1] = useState('');

    const generateText = () => {
        const dataModel = {
            Name: name,
            Address: {
                City: city,
                Line1: line1,
            },
        };

        onGenerateText(template, dataModel);
    };

    return (
        <div className="container">
            <div className="row">
                <div className="col-md-12">
                    <div className="form-group mb-3">
                        <label className="form-label">Template:</label>
                        <input type="text" className="form-control" value={template} onChange={(e) => setTemplate(e.target.value)} />
                    </div>
                    <div className="form-group mb-3">
                        <label className="form-label">Name:</label>
                        <input type="text" className="form-control" value={name} onChange={(e) => setName(e.target.value)} />
                    </div>
                    <div className="form-group mb-3">
                        <label className="form-label">City:</label>
                        <input type="text" className="form-control" value={city} onChange={(e) => setCity(e.target.value)} />
                    </div>
                    <div className="form-group mb-3">
                        <label className="form-label">Line1:</label>
                        <input type="text" className="form-control" value={line1} onChange={(e) => setLine1(e.target.value)} />
                    </div>
                    <button className="btn btn-primary btn-block mt-3" onClick={generateText}>Generate Text</button>
                </div>
            </div>
        </div>
    );


};

export default TextGenerationForm;
