
// Link to Project Assets
import {config} from '../webbuild/Build/buildconfig.js'
import {Unity} from './Unity.js'

export const settings = {
    name: "Unity Template",
    devices: ["EEG", "HEG"],
    author: "Juris Zebneckis",
    description: "",
    categories: ["WIP"],
    instructions:"",

    // App Logic
    graph:
    {
      nodes: [
        // {name:'eeg', class: brainsatplay.plugins.biosignals.EEG},
        // {name:'neurofeedback', class: brainsatplay.plugins.algorithms.Neurofeedback, params: {metric: 'Focus'}},
        {name:'number', class: brainsatplay.plugins.data.Number, params: {}},
        {
          name:'unity', 
          class: Unity, 
          // class: brainsatplay.plugins.utilities.Unity, // still need to fix routing for built-in plugin
          params:{
              config,
              onUnityEvent: (ev) => {
                // Parse Messages from Unity
                if (typeof ev === 'string'){
                  console.log('MESSAGE: ' + ev)
                }
              },
              commands: 
              [
                {
                    object: 'GameApplication',
                    function: 'UpdateSelection',
                    type: 'number'
                },
                // {
                //     object: 'GameApplication',
                //     function: 'UpdateFocus',
                //     type: 'number'
                // },
                // {
                //     object: 'GameApplication',
                //     function: 'UpdateBlink',
                //     type: 'boolean'
                // }
            ]
          }
        },
        {
          name:'ui', 
          class: brainsatplay.plugins.interfaces.UI
        }
    ],

      edges: [

        // BRAIN
        // {
        //   source: 'eeg:atlas',
        //   target: 'neurofeedback',
        // },
        // {
        //   source: 'neurofeedback',
        //   target: 'unity:UpdateFocus',
        // },

          {
            source: 'number:value',
            target: 'unity:UpdateSelection',
          },

        {
          source: 'unity:element',
          target: 'ui:content',
        }
      ]
    },
    connect: true
}