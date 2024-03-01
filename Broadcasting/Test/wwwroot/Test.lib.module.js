export function afterStarted(blazor) {
    blazor.registerCustomEventType('Broadcast', {
        createEventArgs: event => {
            let e = {
                data: globaldata
            };
            return e;
        }
    });
}
